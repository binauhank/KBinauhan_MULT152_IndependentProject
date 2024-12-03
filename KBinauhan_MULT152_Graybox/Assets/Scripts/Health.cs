using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float healthPoints = 5f;
    
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

        if (gameObject.tag == "Player" && healthPoints < 0)
        {
            healthPoints = 0;
        }
        
        if (gameObject.tag == "Enemy")
        {
            print("ENEMY took damage - Health: " + healthPoints);
        }
        
        if (gameObject.tag == "Player")
        {
            print("PLAYER took damage - Health: " + healthPoints);
        }
    }

    public void Heal(float healing)
    {
        healthPoints += healing;

        if (gameObject.tag == "Player" && healthPoints > 5)
        {
            healthPoints = 5;
        }

        print("PLAYER heal - Health: " + healthPoints);
    }
}
