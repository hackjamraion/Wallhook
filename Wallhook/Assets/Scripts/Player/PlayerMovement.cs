using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerBehaviour
{
    public float speed;
    private Vector2 move;
    

    void Update()
    {
        Controller();
    }

    void Controller()
    {
        
        move = Vector2.zero;
        if (Input.GetKey(KeyCode.A) )
        {
            move = Vector2.left;
        } else if (Input.GetKey(KeyCode.D))
        {
            move = Vector2.right;
        }  else if (Input.GetKey(KeyCode.W))
        {
            move = Vector2.up;
        } else if (Input.GetKey(KeyCode.S))
        {
            move = Vector2.down;
        }
        
        Move(move, speed);
    }
}
