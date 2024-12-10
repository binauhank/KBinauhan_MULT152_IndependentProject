using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathSound : MonoBehaviour
{
    private AudioSource asBoss;
    public AudioClip deathSound;

    void Start()
    {
        asBoss = GetComponent<AudioSource>();
    }

    void PlayDeathSound()
    {
        asBoss.PlayOneShot(deathSound, 0.5f);
    }
}
