using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWeapon : MonoBehaviour
{
    public float projSpeed = 30f;
    public GameObject pulseCannon;
    public Rigidbody projectilePrefab;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && pulseCannon.activeSelf == true)
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.velocity = transform.forward * projSpeed;
    }
}
