using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            float damage = 1f;
            other.GetComponent<Health>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
