using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;


public class BackgroundScrollScript : MonoBehaviour
{
    #region Data

    public float Speed = 0;
    [SerializeField] private Camera _camera;

    private Direction _direction = Direction.ToLeft;
    public Direction Direction
    {
        get => _direction;
        set
        {
            _direction = value;
            _scrolling = (_direction != Direction.ToRight) ? (Func<float, bool>)ToLeft : (Func<float, bool>)ToRight;
        }
    }

    private Transform[] _backs;
    private float _x;
    private float _y;
    private Func<float, bool> _scrolling;
    private int _last;

    #endregion



    #region Operations

    private void Start()
    {
        _backs = new Transform[transform.childCount];
        _y = _camera.orthographicSize * 2f;
        _x = (_y * ((float)Screen.width / Screen.height));
        _scrolling = (_direction != Direction.ToRight) ? (Func<float, bool>)ToLeft : (Func<float, bool>)ToRight;
        _last = _backs.Length - 1;

        for (int i = 0; i < _backs.Length; i++)
        {
            Transform back = transform.GetChild(i);

            back.gameObject.GetComponent<SpriteRenderer>().size = new Vector2(_x + 1, _y);
            back.position = new Vector3(_x * i, 0, back.position.z);

            _backs[i] = back;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _backs.Length; i++)
        {
            _backs[i].transform.Translate(new Vector3(Speed * (sbyte)Direction, 0, 0) * Time.deltaTime);

            if (_scrolling(_backs[i].position.x))
            {
                _backs[i].position = new Vector3(
                    _backs[_last].position.x + _x * (-1 * (sbyte)Direction),
                    _backs[i].position.y,
                    _backs[i].position.z);

                _last = i;
            }
        }
    }

    private bool ToRight(float position) => position >= _x;
    private bool ToLeft(float position) => position <= -_x; 

    #endregion
}
