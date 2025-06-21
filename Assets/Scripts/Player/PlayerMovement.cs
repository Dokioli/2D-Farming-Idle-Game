using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator animator;

    [SerializeField] Joystick playerJoystick;
    [SerializeField] float speed;

    Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = playerJoystick.Horizontal;
        movement.y = playerJoystick.Vertical;
    }
    private void FixedUpdate()
    {
        if (movement == Vector2.zero)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", 0);
            animator.SetBool("IsMoving", false);
        }
        else
        {
            rb.linearVelocity = movement.normalized * speed;
            animator.SetFloat("Move X", movement.x);
            animator.SetFloat("Move Y", movement.y);
            animator.SetBool("IsMoving", true);
        }
    }
}
