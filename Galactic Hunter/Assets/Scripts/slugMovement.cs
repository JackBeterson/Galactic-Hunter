using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slugMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Rigidbody2D targetrb;

    private float speed = -2f;

    void Start()
    {
        targetrb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (targetrb != null)
        {
            rb.velocity = new Vector2(Horizonta() * speed, Vertical() * speed);

            if (Horizonta() > 0f)
            {
                Vector3 localScale = transform.localScale;
                localScale.x = 1f;
                transform.localScale = localScale;
            }
            else if (Horizonta() < 0f)
            {
                Vector3 localScale = transform.localScale;
                localScale.x = -1f;
                transform.localScale = localScale;
            }
        }
        else
        {
            return;
        }
    }

    private float Horizonta()
    {
        if (rb.position.x - targetrb.position.x <= -0.1f)
        {
            return -1f;
        }
        else if (rb.position.x - targetrb.position.x >= 0.1f)
        {
            return 1f;
        }
        else
        {
            return 0f;
        }
    }

    private float Vertical()
    {
        if (rb.position.y - targetrb.position.y <= -0.1f)
        {
            return -1f;
        }
        else if (rb.position.y - targetrb.position.y >= 0.1f)
        {
            return 1f;
        }
        else
        {
            return 0f;
        }
    }
}
