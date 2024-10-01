using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        bool playerIsClose = distance <= 6f;
        
        if (playerIsClose)
        {
            enemy.SetDestination(player.position);
        }
    }
}
