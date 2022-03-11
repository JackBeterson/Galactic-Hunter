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
        Vector2 lookDir = targetrb.position - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90;
        rb.rotation = angle;

        if (targetrb != null)
            rb.velocity = new Vector2(Horizonta() * speed, Vertical() * speed);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
