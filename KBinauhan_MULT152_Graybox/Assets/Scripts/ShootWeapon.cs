using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWeapon : MonoBehaviour
{
    private GameManager gameMg;
    
    public float projSpeed = 15f;
    public GameObject pulseCannon;
    public Rigidbody projectilePrefab;
    
    void Start()
    {
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(!gameMg.gameOver)
        {
            if (Input.GetButtonDown("Fire1") && pulseCannon.activeSelf)
            {
                ShootProjectile();
            }
        }
    }

    void ShootProjectile()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.velocity = transform.forward * projSpeed;
    }
}
