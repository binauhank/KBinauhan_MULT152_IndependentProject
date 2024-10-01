using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGrid : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            float damage = 10f;
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
