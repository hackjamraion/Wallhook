using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static bool hasKey;
    public static GameManagement instance;

    public string sceneTarget;

    private void Start()
    {
        hasKey = false;
        instance = this;
    }
}
