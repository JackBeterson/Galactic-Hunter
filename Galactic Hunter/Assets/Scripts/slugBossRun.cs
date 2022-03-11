using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slugBossRun : StateMachineBehaviour
{
    private Rigidbody2D rb;
    private float xVel = 3f;
    private float flipTimmer;
    private float attackTimer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = GameObject.FindGameObjectWithTag("slugBoss").GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
        flipTimmer = Random.value + 2f;
        attackTimer = 3f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        rb.velocity = new Vector2(xVel, rb.velocity.y);
        flipTimmer -= Time.deltaTime;
        attackTimer -= Time.deltaTime;

        if (flipTimmer <= 0f)
        {
            Flip();
        }

        if (attackTimer <= 0f)
        {
            animator.Play("Slug Boss Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = Vector2.zero;
    }

    private void Flip()
    {
        xVel *= -1f;
        Vector3 localScale = rb.transform.localScale;
        localScale.x *= -1f;
        rb.transform.localScale = localScale;
        flipTimmer = Random.value + 2f;
    }
}
