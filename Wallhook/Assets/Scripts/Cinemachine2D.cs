using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Cinemachine2D : MonoBehaviour {

    private Vector2 velocity;

    GameObject player; //Object which will following

    public float smoothTimeY;
    public float smoothTimeX;

    #region Bounding Cam

        #region SizeCam
        public float right;
        public float left;
        public float up;
        public float down;
        #endregion

    public Transform rightBound;
    public Transform leftBound;
    public Transform upBound;
    public Transform downBound;
    #endregion

    private void Update()
    {
        if (transform.GetComponent<Camera>().orthographic)
        {
            try
            {
                player = GameObject.FindGameObjectWithTag("Player"); //Finding the object
                float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
                float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

                transform.position = new Vector3(posX, posY, -10);

                if (/** Bounding Cam Here */true) //For bounding cam
                {
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBound.position.x + left, rightBound.position.x - right), Mathf.Clamp(transform.position.y, downBound.position.y + down, upBound.position.y - up), Mathf.Clamp(-10, -10, -10));
                }
            }
            catch (System.Exception er)
            {

            }
        }
    }
}
