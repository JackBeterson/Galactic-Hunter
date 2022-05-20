using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private GameObject playerHurtbox;
    [SerializeField] private GameObject[] heads;
    
    private int health = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            Damage();
        }
    }

    private void Damage()
    {
        playerHurtbox.SetActive(false);

        StartCoroutine(DamageFlicker());

        health -= 1;
        GameObject.Find("Game Manager").GetComponent<gameManager>().Play("Damage");

        if (health >= 0)
        {
            heads[health].SetActive(false);
        }

        if (health == 0)
        {
            Death();
        }
    }

    private void Death()
    {
        GameObject.Find("Game Manager").GetComponent<buttons>().Loss();

        GameObject.Find("Enemy Spawner").GetComponent<waveSpawner>().canSpawn = false;

        GameObject.Find("Game Manager").GetComponent<gameManager>().Play("Death");

        Destroy(GameObject.Find("ArmHinge"));

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
        Destroy(effect, .2f);
        Destroy(gameObject);
    }

    IEnumerator DamageFlicker()
    {
        for (int i = 0; i < 5f; i++)
        {
            sprite.color = Color.red; // new Color(1f, 1f, 1f, .5f);
            yield return new WaitForSeconds(.1f);
            sprite.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
        playerHurtbox.SetActive(true);
    }
}
