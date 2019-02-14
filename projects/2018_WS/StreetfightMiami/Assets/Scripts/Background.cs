using UnityEngine;

public class Background : MonoBehaviour
{
    /// <summary>
    /// Scrolling speed
    /// </summary>
    public Vector2 speed = new Vector2(2, 2);

    public Vector2 direction;
    public bool isLinkedToCamera = false;

    private Player player = GameObject.Find("CyberPunk").GetComponent<Player>();

    void Update()
    {
        Vector3 movement;
        if (player.facingRight )
        {
            direction = new Vector2(-1, 0);
        } else if(!player.facingRight)
        {
            direction = new Vector2(-1, 0);
        }
        movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
        movement *= Time.deltaTime;
        if (player.isMoving)
        {
            transform.Translate(movement);
        }
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }
    }
}