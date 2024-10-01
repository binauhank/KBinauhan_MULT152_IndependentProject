using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 0.3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Breakable")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            float damage = Random.Range(1, 3);
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
