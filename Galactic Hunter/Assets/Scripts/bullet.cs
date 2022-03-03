using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject hitEffect;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "wall")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, .2f);
            Destroy(gameObject);
        }
    }
}
