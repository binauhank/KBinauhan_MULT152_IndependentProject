using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            float damage = Random.Range(1, 3);
            other.GetComponent<Health>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}