﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{

    public string sceneTarget;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(sceneTarget);
    }
}
