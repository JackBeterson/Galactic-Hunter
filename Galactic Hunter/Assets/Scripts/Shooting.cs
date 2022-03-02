using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public bool firing = false;

    public float bulletForce = 20;

    private void Update()
    {
        if (firing)
        {
            Fireing();
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Fireing();
        }
    }

    private void Fireing()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D bullertrb = bullet.GetComponent<Rigidbody2D>();
        bullertrb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
