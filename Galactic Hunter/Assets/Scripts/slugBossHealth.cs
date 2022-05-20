using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slugBossHealth : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Slider slider;

    private float health;
    private float multiplier; 

    void Start()
    {
        multiplier = GameObject.Find("Game Manager").GetComponent<gameManager>().difficulty;
        health = 15 * multiplier;
        slider.maxValue = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bullet")
        {
            Damage();
        }
    }

    private void Damage()
    {
        sprite.color = Color.red;

        health -= 1;
        GameObject.Find("Game Manager").GetComponent<gameManager>().Play("Boss Damage");
        slider.value = health;

        Invoke("DamageReset", .25f);

        if (health == 0)
        {
            Death();
        }
    }

    private void Death()
    {
        GameObject.Find("Game Manager").GetComponent<buttons>().Win();

        GameObject.Find("Enemy Spawner").GetComponent<waveSpawner>().canSpawn = false;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyHealth eH = enemies[i].GetComponent<enemyHealth>();

            if (eH != null)
            {
                eH.Death();
            }
            else
            {
                Destroy(enemies[i]);
            }
        }

        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effect, 1f);
        Destroy(gameObject);
    }

    private void DamageReset()
    {
        sprite.color = Color.white;
    }
}
