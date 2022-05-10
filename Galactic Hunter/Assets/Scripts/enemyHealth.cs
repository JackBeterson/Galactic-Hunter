using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private SpriteRenderer sprite;
    private float health;

    private void Start()
    {
        health = GameObject.Find("Game Manager").GetComponent<gameManager>().difficulty;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            sprite.color = Color.red;

            health -= 1;
            Invoke("DamageReset", .25f);

            if (health == 0)
            {
                Death();
            }
        }
    }

    public void Death()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effect, .5f);
        Destroy(gameObject);
    }

    private void DamageReset()
    {
        sprite.color = Color.white;
    }
}
