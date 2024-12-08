using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    private Animator animEnemy;
    private BoxCollider boxCollider;
    private GameManager gameMg;

    void Start()
    {
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animEnemy = GetComponent<Animator>();
        boxCollider = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        bool playerIsClose = distance <= 6f;
        bool canPunch = distance <= 1.5f;
        
        if (playerIsClose && gameMg.gameOver == false)
        {
            Walk();
        }
        else
        {
            // Idle
            animEnemy.SetBool("Walk_bool", false);
            playerIsClose = false;
        }

        if (canPunch && gameMg.gameOver == false)
        {
            Attack();
        }
    }

    void Walk()
    {
        enemy.SetDestination(player.position);
        animEnemy.SetBool("Walk_bool", true);
    }

    void Attack()
    {
        if (!animEnemy.GetCurrentAnimatorStateInfo(0).IsName("Hook Punch"))
        {
            animEnemy.SetTrigger("Punch_trig");
            enemy.SetDestination(transform.position);
        }
    }

    void EnableAttack()
    {
        boxCollider.enabled = true;
    }

    void DisableAttack()
    {
        boxCollider.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<ThirdPersonController>();

        if (player != null)
        {
            other.GetComponent<Health>().TakeDamage(0.5f);
        }
    }
}
