using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;

public class GroundScrollScript : MonoBehaviour
{
    #region Data

    public ReversibleDirection<float, bool> Reversible;

    private Transform[] _grounds;
    private float _x;
    private int _current;
    private int _last;

    #endregion


    #region Operations

    private void Start()
    {
        Reversible = new ReversibleDirection<float, bool>(Direction.ToLeft,
            position => position <= 0, 
            position => position >= 0);

        _grounds = new Transform[transform.childCount];
        _x = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x - 1;

        _current = 0;
        _last = transform.childCount - 1;

        for (int i = 0; i < _grounds.Length; i++)
        {
            Transform ground = transform.GetChild(i);
            ground.position = new Vector3(i * _x, Values.GROUND_TOP_POSITION, ground.position.z);
            _grounds[i] = ground;
        }
    }


    private void Update()
    {
        for (int i = 0; i < _grounds.Length; i++)
        {
            _grounds[i].transform.Translate(new Vector3(Values.SpeedOfGame * (sbyte)Reversible.Direction, 0, 0) * Time.deltaTime);
            if (i == _last && Reversible.Action(_grounds[_last].position.x))
            {
                _grounds[_current].position = new Vector3(
                    _grounds[_last].position.x + _x * (-1 * (sbyte)Reversible.Direction),
                    _grounds[_current].position.y,
                    _grounds[_current].position.z
                    );

                _last = _current;
                _current = i;
            }
        }
    }

    #endregion
}
