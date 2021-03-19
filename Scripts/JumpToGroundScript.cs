using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToGroundScript : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovingScript pm = collision.collider.GetComponent<PlayerMovingScript>();
        if (pm != null)
        {
            pm.IsJump = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
