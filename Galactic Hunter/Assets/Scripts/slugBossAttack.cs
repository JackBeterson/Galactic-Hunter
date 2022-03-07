using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slugBossAttack : StateMachineBehaviour
{
    private Rigidbody2D rb;
    public float attackTimer;
    private GameObject enemy;
    private Transform hand;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = GameObject.FindGameObjectWithTag("slugBoss").GetComponent<Rigidbody2D>();
        hand = GameObject.Find("L Hand").GetComponent<Transform>();
        //enemy = GameObject.Find("Slug");
        attackTimer = .5f;
        Debug.Log("dadsa");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackTimer -= Time.deltaTime;
        Debug.Log(attackTimer);
        Vector2 spawnPos = hand.position;
        spawnPos += new Vector2(-5f, 0f);
        if (attackTimer <= 0)
        {
            Debug.Log("atack");
            //Instantiate(enemy, spawnPos, Quaternion.identity);
            attackTimer = .5f;
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
