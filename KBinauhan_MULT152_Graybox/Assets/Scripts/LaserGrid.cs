using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGrid : MonoBehaviour
{
    private Health healthScript;

    void Start()
    {
        healthScript = GameObject.Find("Player").GetComponent<Health>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("DamageOnContact", 0.1f, 1f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CancelInvoke("DamageOnContact");
        }
    }

    void DamageOnContact()
    {
        float damage = 1f;
        healthScript.TakeDamage(damage);
    }
}
