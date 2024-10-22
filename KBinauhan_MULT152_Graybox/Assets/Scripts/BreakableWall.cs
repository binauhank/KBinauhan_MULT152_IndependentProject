using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private AudioSource asWall;
    private ParticleSystem explosion;

    public AudioClip breakSound;

    void Start()
    {
        asWall = GetComponent<AudioSource>();
        explosion = GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerProjectile")
        {
            explosion.Play();
            asWall.PlayOneShot(breakSound, 0.5f);

            Destroy(gameObject, 1.25f);
        }
    }
}
