using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    private Animator animEnemy;
    private GameManager gameMg;

    void Start()
    {
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();
        animEnemy = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        bool playerIsClose = distance <= 6f;
        bool canPunch = distance <= 1.5f;
        
        if (playerIsClose && gameMg.gameOver == false)
        {
            enemy.SetDestination(player.position);
            animEnemy.SetBool("Walk_bool", true);
        }
        else
        {
            animEnemy.SetBool("Walk_bool", false);
            playerIsClose = false;
        }

        if (canPunch && gameMg.gameOver == false)
        {
            animEnemy.SetTrigger("Punch_trig");
        }
    }
}
