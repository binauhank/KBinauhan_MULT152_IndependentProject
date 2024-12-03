using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Rigidbody projectilePrefab;
    private float shootSpeed = 3;
    private float fireRate = 1f;

    private bool playerInRange = false;
    private Transform player = null;
    private Health healthScript;
    private GameManager gameMg;

    void Start()
    {
        healthScript = GetComponentInParent<Health>();
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

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
            Vector3 rot = Quaternion.LookRotation(player.position - transform.position).eulerAngles;
            rot.x = rot.z = 0;
            transform.parent.rotation = Quaternion.Euler(rot);
        }

        if (healthScript.healthPoints <= 0 || gameMg.gameOver == true)
        {
            CancelInvoke("ShootBullet");
        }
    }

    void ShootBullet()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.velocity = transform.forward * shootSpeed;
    }
}