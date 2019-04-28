using UnityEngine;

public class GravityManipulator : MonoBehaviour
{
    [SerializeField] private float timeWallGrep;
    [SerializeField] private float timeCeilGrep;
    private float time;

    public static bool falling;
    private Rigidbody2D rb2d;
    private PlayerBehaviour player;
    private PlayerHook _hook;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();
        rb2d = GetComponent<Rigidbody2D>();
        _hook = GetComponent<PlayerHook>();
    }

    // Update is called once per frame
    void Update()
    {
        waktuBertahan();
    }

    void waktuBertahan()
    {
        if (_hook.inHook) time = 0;
        if (!falling)
        {
            if (player.OnCeil())
            {
                timer(timeCeilGrep);
            }
            else if (player.OnWall())
            {
                timer(timeWallGrep);
            }
            else if (player.OnFalling() && !_hook.inHook)
            {
                falling = true;
                time = 0;
            }
        }

        rb2d.gravityScale = falling ? 1 : 0;
    }

    void timer(float timeAwal)
    {
        if (time >= timeAwal)
        {
            time = 0;
            falling = true;
            player.toggle();
        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
