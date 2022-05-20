using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverseBullet : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("enemy"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, .4f);
            Destroy(gameObject);
        }
        if (other.CompareTag("wall"))
        {
            GameObject.Find("Game Manager").GetComponent<gameManager>().Play("Hit Wall");
        }
        if (other.CompareTag("bullet"))
        {
            GameObject.Find("Game Manager").GetComponent<gameManager>().Play("Hit Bullet");
        }
    }
}
