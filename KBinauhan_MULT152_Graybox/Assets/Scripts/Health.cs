using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float playerHealth = 20f;
    public float enemyHealth = 10f;
    
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Game over!");
            // reload scene
        }
    }

    public void TakeDamage(float damageTaken)
    {
        if (gameObject.tag == "Enemy")
        {
            enemyHealth -= damageTaken;
            Debug.Log("Enemy health: " + enemyHealth);
        }
        
        if (gameObject.tag == "Player")
        {
            playerHealth -= damageTaken;
            Debug.Log("Player health: " + playerHealth);
        }
    }
}
