using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public Rigidbody projectilePrefab;
    private float shootSpeed = 3;
    private float fireRate = 1f;

    private bool playerInRange = false;
    private Transform player = null;
    private Health healthScript;
    private Animator bossAnim;
    private GameManager gameMg;

    private Boss bossScript;

    public Rigidbody phaseTwoProjectile;

    void Start()
    {
        healthScript = GetComponentInParent<Health>();
        bossAnim = GetComponentInParent<Animator>();
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();

        bossScript = GetComponentInParent<Boss>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
            player = other.transform;
            StartCoroutine(BossAttack());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
            player = null;
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

        if (bossScript.phaseTwo)
        {
            shootSpeed = 5f;
            fireRate = 0.75f;
        }
    }

    void ShootBullet()
    {
        if (bossScript.phaseTwo)
        {
            var projectile = Instantiate(phaseTwoProjectile, transform.position, transform.rotation);
            projectile.velocity = transform.forward * shootSpeed;
        }
        else
        {
            var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            projectile.velocity = transform.forward * shootSpeed;
        }
    }

    IEnumerator BossAttack()
    {
        while (healthScript.healthPoints > 0 && playerInRange && !gameMg.gameOver)
        {
            bossAnim.SetTrigger("Shoot_trig");
            yield return new WaitForSeconds(fireRate);
            ShootBullet();
        }
    }
}
