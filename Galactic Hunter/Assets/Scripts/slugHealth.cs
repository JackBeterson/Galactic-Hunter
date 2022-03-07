using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slugHealth : MonoBehaviour
{
    //private float health = 1;
    public GameObject deathEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            Death();
        }
    }
    private void Death()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effect, .2f);
        GameObject.Find("Enemy Spawner").GetComponent<enemySpawner>().EnemyDead();
        Destroy(gameObject);
    }
}
