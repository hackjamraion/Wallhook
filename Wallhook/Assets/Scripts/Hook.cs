using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float speed = 10;
    private GameObject parent;
    
    void Update()
    {
        transform.Translate(Vector2.right*speed*Time.deltaTime);
    }

    public void searchAngle(Vector2 target, GameObject player)
    {
        parent = player;
        Vector3 difference = target - (Vector2) transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Wall"))
        {
            parent.GetComponent<PlayerHook>().Hooking();
            Destroy(transform.gameObject);
        }
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
