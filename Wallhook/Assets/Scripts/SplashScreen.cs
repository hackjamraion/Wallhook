using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SplashScreen : MonoBehaviour {

    public Image splashScreening;
    public string loadingLevel;

    IEnumerator Start() 
    {
        splashScreening.canvasRenderer.SetAlpha(0.0f);

        fadeIn();
        yield return new WaitForSeconds(3.0f);
        fadeOut();
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(loadingLevel);
    }

    void fadeIn() 
    {
        splashScreening.CrossFadeAlpha(1.0f, 2.0f, false);
    }

    void fadeOut() 
    {
        splashScreening.CrossFadeAlpha(0.0f, 2.5f, false);
    }

}
