using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthPoints = 5f;
    
    void Update()
    {
        if (gameObject.tag == "Player" && healthPoints > 5)
        {
            healthPoints = 5;
        }
        
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
            Debug.Log("DAMAGE - Enemy health: " + healthPoints);
        }
        
        if (gameObject.tag == "Player")
        {
            Debug.Log("DAMAGE - Player health: " + healthPoints);
        }
    }

    public void Heal(float healing)
    {
        healthPoints += healing;

        if (gameObject.tag == "Player")
        {
            Debug.Log("HEAL - Player health: " + healthPoints);
        }
    }
}
