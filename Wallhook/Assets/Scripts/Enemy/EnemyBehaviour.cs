using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject visionField;
    private Vector2 min, max;
    private Vector2 direction = Vector2.right;

    [SerializeField] private float speed;

    private EnemyVision vision;
    
    void Start()
    {
        min = new Vector2( visionField.transform.position.x + ((-visionField.GetComponent<BoxCollider2D>().size.x/2) + visionField.GetComponent<BoxCollider2D>().offset.x) ,0);    
        max = new Vector2( visionField.transform.position.x + (visionField.GetComponent<BoxCollider2D>().size.x/2 + visionField.GetComponent<BoxCollider2D>().offset.x) ,0);
        vision = GetComponentInParent<EnemyVision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vision.inArea)
        {
            DoKamikaze();
        } else Patrol();
    }

    void Patrol()
    {        
        transform.Translate(direction*speed*Time.deltaTime);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, min.x, max.x), transform.position.y);
        if (transform.position.x == max.x) direction = Vector2.left;
        if (transform.position.x == min.x) direction =Vector2.right;
    }

    void DoKamikaze()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(vision.target.transform.position.x , transform.position.y), 0.14f);
    }
    
    
}
