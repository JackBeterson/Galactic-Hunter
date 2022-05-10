using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D armHinge;
    [SerializeField] private Animator animator;
    [SerializeField] private Camera cam;

    private Vector2 mousePos;

    private bool isFacingRight = true;

    private float horizontal;
    private float vertical;
    private float speed = 8f;

    void Update()
    {
        armHinge.position = rb.position;

        Vector2 lookDir = mousePos - armHinge.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        armHinge.MoveRotation(angle);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        if (context.performed)
        {
            animator.Play("Player Run");
        }
        else if (context.canceled)
        {
            animator.Play("Player Idle");
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Aim(InputAction.CallbackContext context)
    {
        mousePos = cam.ScreenToWorldPoint(context.ReadValue<Vector2>());

        float diff = Mathf.Sign(rb.position.x - mousePos.x);

        if (!isFacingRight && diff < 0f)
        {
            Flip();
        }
        else if (isFacingRight && diff > 0f)
        {
            Flip();
        }
    }
}
