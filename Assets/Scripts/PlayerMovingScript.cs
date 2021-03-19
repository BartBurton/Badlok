using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingScript : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D _playerRb;
    private Vector2 _velocity = new Vector2(0, 0);

    public bool IsJump { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        _velocity.x = inputX * Speed;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!IsJump)
            {
                _playerRb.gravityScale *= -1;
                IsJump = true;
            }
        }
    }

    public void FixedUpdate()
    {
        _playerRb.velocity = _velocity;
    }
}
