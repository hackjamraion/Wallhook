﻿using UnityEngine;

public class PlayerHook : PlayerBehaviour
{
    private Vector2 hook;
    private Vector2 direction;
    [SerializeField] private bool inHook;
    private RaycastHit2D ray;
    [SerializeField] private LayerMask layer;
    [SerializeField] Vector2 moveTo = Vector2.zero;

    [SerializeField] private Grid grid;

    [Range(0,2)] [SerializeField] private float hookRange;

    [SerializeField] private GameObject hookProjectile;

    private bool cantHook;

    void FixedUpdate()
    {
        Hook();
    }
    
    void Hook()
    {

        if (Input.GetMouseButtonDown(0) && !cantHook)
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (target - (Vector2) transform.position).normalized;
        
            ray = Physics2D.Raycast(transform.position, direction, int.MaxValue, layer.value);
            if (ray.collider != null && ray.collider.tag.Equals("Wall"))
            {
                hook = ray.point;
              
                if (ray.distance > hookRange)
                {
                    cantHook = true;
                    GameObject tempo = Instantiate(hookProjectile, transform.position, Quaternion.identity);
                    tempo.GetComponent<Hook>().searchAngle(hook, transform.gameObject);
                }
                moveTo = hook;
                
            }      
        }  

        if (inHook)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveTo, 0.4f);
        }

        if ((Vector2) transform.position == moveTo && inHook)
        {
            inHook = false;
            cantHook = false;
        }     
        
    }
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Wall"))
        {
            inHook = false;
            cantHook = false;
        }

        
    }

    public void Hooking()
    {
        inHook = true;
    }
}
