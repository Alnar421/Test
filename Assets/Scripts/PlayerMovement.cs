using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public VirtualJoystick joystick;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (joystick != null)
        {
            Vector2 dir = joystick.Direction;
            if (dir.magnitude > 0.1f)
            {
                moveX = dir.x;
                moveY = dir.y;
            }
        }

        movement = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = movement * moveSpeed;
        }
    }
}
