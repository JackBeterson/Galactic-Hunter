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
    }
}
