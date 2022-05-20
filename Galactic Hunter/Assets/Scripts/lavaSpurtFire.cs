using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaSpurtFire : StateMachineBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private Transform firepoint;

    private float bulletForce = 7.5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        firepoint = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("Game Manager").GetComponent<gameManager>().Play("Lava Shooting");

        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, new Quaternion(0f, 0f, 0f, 0f));
        Rigidbody2D bullertrb = bullet.GetComponent<Rigidbody2D>();
        bullertrb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrefab, firepoint.position, new Quaternion(0, 0, -0.7f, 0.7f));
        Rigidbody2D bullertrb2 = bullet2.GetComponent<Rigidbody2D>();
        bullertrb2.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(bulletPrefab, firepoint.position, new Quaternion(0f, 0f, 180f, 0f));
        Rigidbody2D bullertrb3 = bullet3.GetComponent<Rigidbody2D>();
        bullertrb3.AddForce(-firepoint.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet4 = Instantiate(bulletPrefab, firepoint.position, new Quaternion(0, 0, 0.7f, 0.7f));
        Rigidbody2D bullertrb4 = bullet4.GetComponent<Rigidbody2D>();
        bullertrb4.AddForce(-firepoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
