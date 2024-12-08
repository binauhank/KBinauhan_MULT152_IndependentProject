using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWeapon : MonoBehaviour
{
    private GameManager gameMg;
    private Animator animPlayer;
    
    private float projSpeed = 30f;
    private bool canShoot = true;
    public GameObject pulseCannon;
    public Rigidbody projectilePrefab;
    
    void Start()
    {
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animPlayer = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if(!gameMg.gameOver)
        {
            if (Input.GetButtonDown("Fire1") && pulseCannon.activeSelf && canShoot)
            {
                StartCoroutine(ShootProjectile());
                canShoot = false;
            }
        }
    }

    IEnumerator ShootProjectile()
    {
        animPlayer.SetTrigger("Shoot_trig");
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.velocity = transform.forward * projSpeed;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
