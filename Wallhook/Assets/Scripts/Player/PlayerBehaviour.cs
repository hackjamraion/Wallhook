using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
  
   
    public void Move(Vector2 direction , float speed)
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    
}
