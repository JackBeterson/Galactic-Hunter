using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverseHunterShooting : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Rigidbody2D armHinge;
    [SerializeField] private Rigidbody2D targetrb;
    [SerializeField] private GameObject sprite;

    private float bulletForce = 20;
    private float shootCoolCounter = 1f;

    private void Start()
    {
        targetrb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (targetrb != null)
        {
            armHinge.rotation = Angle();

            if (shootCoolCounter > 0f)
            {
                shootCoolCounter -= Time.deltaTime;
            }
            else if (shootCoolCounter <= 0f)
            {
                Shoot();
            }

            if (Horizonta() < 0f)
            {
                Vector3 localScale = transform.localScale;
                localScale.x = 1f;
                sprite.transform.localScale = localScale;
            }
            else if (Horizonta() > 0f)
            {
                Vector3 localScale = transform.localScale;
                localScale.x = -1f;
                sprite.transform.localScale = localScale;
            }
        }
        else
        {
            return;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D bullertrb = bullet.GetComponent<Rigidbody2D>();
        bullertrb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);

        shootCoolCounter = .75f;

        GameObject.Find("Game Manager").GetComponent<gameManager>().Play("Shooting");
    }

    private float Angle()
    {
        Vector2 lookDir = targetrb.position - armHinge.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        return angle;
    }

    private float Horizonta()
    {
        if (armHinge.position.x - targetrb.position.x <= -1)
        {
            return -1f;
        }
        else if (armHinge.position.x - targetrb.position.x >= 1)
        {
            return 1f;
        }
        else
        {
            return 0f;
        }
    }
}
