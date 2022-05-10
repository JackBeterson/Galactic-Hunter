using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class shooting : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject bulletPrefab;

    private bool firing = false;

    private float bulletForce = 20;
    private float shootCoolCounter;

    private void Update()
    {
        if (firing == true)
        {
            Fireing();
        }

        if (shootCoolCounter > 0f)
        {
            shootCoolCounter -= Time.deltaTime;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            firing = true;
        }

        if (context.canceled)
        {
            firing = false;
        }
    }

    private void Fireing()
    {
        if (shootCoolCounter <= 0f)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D bullertrb = bullet.GetComponent<Rigidbody2D>();
        bullertrb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);

        shootCoolCounter = .5f;
    }
}
