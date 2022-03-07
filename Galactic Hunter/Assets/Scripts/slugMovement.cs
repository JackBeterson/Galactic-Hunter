using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slugMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Rigidbody2D targetrb;
    private float speed = -2f;

    private void Start()
    {
        targetrb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (targetrb != null)
        rb.velocity = new Vector2(Horizonta() * speed, Vertical() * speed);

        if (Horizonta() > 0f)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = 1f;
            transform.localScale = localScale;
        }

        if (Mathf.Sign(Horizonta()) < 0f)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -1f;
            transform.localScale = localScale;
        }
    }

    private float Horizonta()
    {
        return Mathf.Sign(rb.position.x - targetrb.position.x);
    }

    private float Vertical()
    {
        return Mathf.Sign(rb.position.y - targetrb.position.y);
    }
}
