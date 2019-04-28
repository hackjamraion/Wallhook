using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    //kecepatan character run
    public float topSpeed = 20f;
    //arah sprite
    bool facingRight = true;

    //get reference to animator
    Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate() 
    {
        //arah gerak
        float move = Input.GetAxis("Horizontal");

        //add velocity to the rigidbody in the move direction * our speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));

        //arah flip
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    void Flip() 
    {
        //facing the oposite directions
        facingRight = !facingRight;

        //get the local scale
        Vector3 theScale = transform.localScale;

        //flip on x axis
        theScale.x *= -1;

        //apply that to the local scale
        transform.localScale = theScale;
    }
}
