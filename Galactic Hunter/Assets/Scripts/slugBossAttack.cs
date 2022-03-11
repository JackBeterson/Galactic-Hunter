using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slugBossAttack : StateMachineBehaviour
{
    [SerializeField] private GameObject enemy;
    private Animator camAnimator;
    private Rigidbody2D rb;
    private float attackTimer;
    private Transform hand;
    private float attacksDone;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = GameObject.FindGameObjectWithTag("slugBoss").GetComponent<Rigidbody2D>();
        camAnimator = GameObject.Find("Main Camera").GetComponent<Animator>();
        hand = GameObject.Find("L Hand").GetComponent<Transform>();
        attackTimer = .16f;
        attacksDone += 1f;
        if (attacksDone == 6)
        {
            animator.Play("Follow Player");
            camAnimator.Play("Cam To Stage 2");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackTimer -= Time.deltaTime;
        Vector2 spawnPos = hand.position;
        spawnPos += new Vector2(0f, -7.5f);
        if (attackTimer <= 0)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
            attackTimer = .33f;
            Flip();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    private void Flip()
    {
        Vector3 localScale = rb.transform.localScale;
        localScale.x *= -1f;
        rb.transform.localScale = localScale;
    }
}
