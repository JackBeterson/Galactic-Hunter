using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    private float health = 3;
    public GameObject deathEffect;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private GameObject playerHurtbox;
    //[SerializeField] private GameObject gameManager;

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
        Invoke("DamageReset", 2.5f);

        if (health == 2)
        {
            GameObject.Find("Head 3").SetActive(false);
        }
        else if (health == 1)
        {
            //GameObject.Find("Head 3").SetActive(false);
            GameObject.Find("Head 2").SetActive(false);
        }
        if (health == 0)
        {
            GameObject.Find("Head 1").SetActive(false);
            Invoke("Death", 0f);
        }

    }

    private void DamageReset()
    {
        playerHurtbox.SetActive(true);
        StopCoroutine(DamageFlicker());
    }
    private void Death()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effect, .2f);
        GameObject.Find("Game Manager").GetComponent<gameManager>().RestartLevel();
        Destroy(gameObject);
    }

    IEnumerator DamageFlicker()
    {
        for (int i = 0; i < 3f; i++)
        {
            sprite.color = new Color(1f, 1f, 1f, .5f);
            yield return new WaitForSeconds(.1f);
            sprite.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }
}
