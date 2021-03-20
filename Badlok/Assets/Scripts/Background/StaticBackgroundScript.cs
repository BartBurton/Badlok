using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBackgroundScript : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    void Start()
    {
        float y = _camera.orthographicSize * 2f;
        float x = y * ((float)Screen.width / Screen.height);

        GetComponent<SpriteRenderer>().size = new Vector2(x, y);
        transform.position = new Vector3(0, 0, transform.position.z);
    }
}
