using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, .4f);
            Destroy(gameObject);
        }
        if (other.CompareTag("wall"))
        {
            GameObject.Find("Game Manager").GetComponent<gameManager>().Play("Hit Wall");
        }
    }
}
