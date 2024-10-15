using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    private GameManager gameMg;

    void Start()
    {
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        bool playerIsClose = distance <= 6f;
        
        if (playerIsClose && gameMg.gameOver == false)
        {
            enemy.SetDestination(player.position);
        }
    }
}
