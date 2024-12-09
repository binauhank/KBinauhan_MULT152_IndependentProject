using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private AudioSource asPlayer;
    public AudioClip hitsound;
    
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            float damage = 1f;
            other.GetComponent<Health>().TakeDamage(damage);

            asPlayer = other.GetComponent<AudioSource>();
            asPlayer.PlayOneShot(hitsound, 0.15f);

            Destroy(gameObject);
        }
    }
}