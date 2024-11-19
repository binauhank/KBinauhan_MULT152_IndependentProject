using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            float damage = Random.Range(1, 3);
            other.GetComponent<Health>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
