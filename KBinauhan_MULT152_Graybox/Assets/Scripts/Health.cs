using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthPoints = 20f;
    
    void Update()
    {
        if (!(gameObject.tag == "Player") && healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damageTaken)
    {
        healthPoints -= damageTaken;
        
        if (gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy health: " + healthPoints);
        }
        
        if (gameObject.tag == "Player")
        {
            Debug.Log("Player health: " + healthPoints);
        }
    }
}
