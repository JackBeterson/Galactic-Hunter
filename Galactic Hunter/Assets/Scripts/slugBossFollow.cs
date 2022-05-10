using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slugBossFollow : StateMachineBehaviour
{
    private Rigidbody2D rb;
    private Rigidbody2D targetrb;

    private float speed = -3f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = GameObject.FindGameObjectWithTag("slugBoss").GetComponent<Rigidbody2D>();
        targetrb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.rotation = Angle();

        if (targetrb != null)
        {
            rb.velocity = new Vector2(Horizonta() * speed, Vertical() * speed);
        }
    }

    private float Angle()
    {
        if (Horizonta() == -1 && Vertical() == 1)
        {
            return 45f;
        }
        else if (Horizonta() == -1 && Vertical() == 0)
        {
            return 90f;
        }
        else if (Horizonta() == -1 && Vertical() == -1)
        {
            return 135f;
        }
        else if (Horizonta() == 0 && Vertical() == -1)
        {
            return 180f;
        }
        else if (Horizonta() == 1 && Vertical() == -1)
        {
            return 225f;
        }
        else if (Horizonta() == 1 && Vertical() == 0)
        {
            return 270f;
        }
        else if (Horizonta() == 1 && Vertical() == 1)
        {
            return 315f;
        }
        else
        {
            return 0f;
        }
    }

    private float Horizonta()
    {
        if (rb.position.x - targetrb.position.x <= -1)
        {
            return -1f;
        }
        else if (rb.position.x - targetrb.position.x >= 1)
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
        if (rb.position.y - targetrb.position.y <= -1)
        {
            return -1f;
        }
        else if (rb.position.y - targetrb.position.y >= 1)
        {
            return 1f;
        }
        else
        {
            return 0f;
        }
    }
}
