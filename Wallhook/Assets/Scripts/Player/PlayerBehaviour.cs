using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    #region Edge Bounding
    private RaycastHit2D ray;
    private bool leftGround, rightGround, upGround, downGround;
    public bool bound1, bound2;
    private float xEdge, yEdge;
    
    public float modifier;
    #endregion
   
    public void Move(Vector2 direction , float speed)
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    public void SetUpEdge()
    {
        xEdge = transform.GetComponent<BoxCollider2D>().size.x/(float) 3;
        yEdge = transform.GetComponent<BoxCollider2D>().size.y/(float) 3;
    }

    public void checkGround()
    {
        if (GravityManipulator.falling)
        {
            ray = Physics2D.Raycast(transform.position, Vector2.down, 2*modifier, LayerMask.GetMask("Wall"));
            //Debug.DrawLine(transform.position, transform.position + Vector3.down * modifier , Color.blue);

            if (ray.collider != null && ray.collider.tag.Equals("Wall"))
            {
                downGround = true;
                GravityManipulator.falling = false;
            }

            return;
        }
        downGround = false;
        upGround = false;
        leftGround = false;
        rightGround = false;
        
        ray = Physics2D.Raycast(transform.position, Vector2.down, 2*modifier, LayerMask.GetMask("Wall"));
        //Debug.DrawLine(transform.position, transform.position + Vector3.down * modifier , Color.blue);

        if (ray.collider != null && ray.collider.tag.Equals("Wall"))
        {
            downGround = true;
        }
        
        ray = Physics2D.Raycast(transform.position, Vector2.up, 2*modifier, LayerMask.GetMask("Wall"));
        //Debug.DrawLine(transform.position, transform.position + Vector3.up * modifier , Color.blue);

        if (ray.collider != null && ray.collider.tag.Equals("Wall"))
        {
            upGround = true;
        }

        if (!upGround && !downGround)
        {
            ray = Physics2D.Raycast(transform.position, Vector2.left, 2*modifier, LayerMask.GetMask("Wall"));
            //Debug.DrawLine(transform.position, transform.position + Vector3.left * modifier, Color.blue);

            if (ray.collider != null && ray.collider.tag.Equals("Wall"))
            {
                leftGround = true;
            }

            ray = Physics2D.Raycast(transform.position, Vector2.right, 2*modifier, LayerMask.GetMask("Wall"));
            //Debug.DrawLine(transform.position, transform.position + Vector3.right * modifier, Color.blue);

            if (ray.collider != null && ray.collider.tag.Equals("Wall"))
            {
                rightGround = true;
            }
        }
        
        if (upGround) checkingBound(Vector3.up, xEdge);
        if (downGround) checkingBound(Vector3.down, xEdge);
        if (leftGround) checkingBound(Vector3.left, yEdge);
        if (rightGround) checkingBound(Vector3.right, yEdge);
    }

    void checkingBound(Vector3 direction, float multiplier)
    {
        bound1 = false;
        bound2 = false;
        Vector3 temp = new Vector3(direction.y,direction.x,direction.z);
        
        ray = Physics2D.Raycast(transform.position + (-temp)*multiplier, direction, modifier, LayerMask.GetMask("Wall"));
        Debug.DrawLine(transform.position + (-temp)*multiplier , transform.position + (-temp)*multiplier + direction * modifier, Color.blue);

        if (ray.collider != null && ray.collider.tag.Equals("Wall"))
        {
            bound1 = true;
        }
        
        ray = Physics2D.Raycast(transform.position + temp*multiplier, direction, modifier, LayerMask.GetMask("Wall"));
        Debug.DrawLine(transform.position + temp*multiplier , transform.position + temp*multiplier + direction * modifier, Color.red);

        if (ray.collider != null && ray.collider.tag.Equals("Wall"))
        {
            bound2 = true;
        }
    }

    public bool horizontalMove()
    {
        return leftGround || rightGround;
    }
    
    public bool verticalMove()
    {
        return downGround || upGround;
    }

    public bool OnWall()
    {
        return leftGround || rightGround;
    }

    public bool OnCeil()
    {
        return upGround;
    }

    public void toggle()
    {
        upGround = downGround = leftGround = rightGround = false;
    }

    public bool OnFalling()
    {
        return !upGround && !downGround && !leftGround && !rightGround;
    }
}
