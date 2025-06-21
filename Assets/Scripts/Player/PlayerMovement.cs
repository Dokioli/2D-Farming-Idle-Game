using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator animator;

    [SerializeField] Joystick playerJoystick;
    [SerializeField] float speed;
}
