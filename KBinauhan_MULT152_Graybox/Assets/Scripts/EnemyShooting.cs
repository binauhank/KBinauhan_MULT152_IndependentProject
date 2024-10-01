using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Rigidbody projectilePrefab;
    public float shootSpeed = 3;
    public float fireRate = 1f;

    private bool playerInRange = false;
    private Transform player = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
            player = other.transform;
            InvokeRepeating("ShootBullet", 1f, fireRate);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
            player = null;
            CancelInvoke("ShootBullet");
        }
    }

    void Update()
    {
        if (playerInRange)
        {
            transform.rotation = Quaternion.LookRotation(player.position - transform.position, transform.up);
        }
    }

    void ShootBullet()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.velocity = transform.forward * shootSpeed;
    }
}