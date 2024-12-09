using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public Rigidbody projectilePrefab;
    private float shootSpeed = 3f;
    private float fireRate = 1.75f;

    private bool playerInRange = false;
    private Transform player = null;
    private Health healthScript;
    private Animator bossAnim;
    private GameManager gameMg;

    private AudioSource asBoss;
    public AudioClip shootSound;

    private Boss bossScript;

    public Rigidbody phaseTwoProjectile;

    void Start()
    {
        healthScript = GetComponentInParent<Health>();
        bossAnim = GetComponentInParent<Animator>();
        asBoss = GetComponentInParent<AudioSource>();
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
        if (!gameMg.gameOver && healthScript.healthPoints > 0)
        {
            if (playerInRange)
            {
                Vector3 rot = Quaternion.LookRotation(player.position - transform.position).eulerAngles;
                rot.x = rot.z = 0;
                transform.parent.rotation = Quaternion.Euler(rot);
            }
        }

        if (bossScript.phaseTwo)
        {
            shootSpeed = 4f;
            fireRate = 1.5f;
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

        asBoss.PlayOneShot(shootSound, 0.15f);
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
