using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D armHinge;
    private Animator animator;

    //[SerializeField] private Transform armJoint;
    [SerializeField] private Camera cam;
    public bool isFacingRight = true;
    public float horizontal;
    public float vertical;
    public float speed = 8f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        armHinge.position = rb.position;
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
        Vector2 mousePos = cam.ScreenToWorldPoint(context.ReadValue<Vector2>());

        Vector2 lookDir = mousePos - armHinge.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        armHinge.MoveRotation (angle);

        float diff = Mathf.Sign(rb.position.x - mousePos.x);

        //Debug.Log(diff);

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
