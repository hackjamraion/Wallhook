using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManagement : MonoBehaviour
{
    
    void CheckingKey()
    {
        if (GameManagement.hasKey)
        {
            SceneManager.LoadScene(GameManagement.instance.sceneTarget);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            CheckingKey();
        }
    }
}
