using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Renderer platformRenderer;
    private Health bossHealth;
    private AudioSource asBoss;
    private ParticleSystem explosion;

    public AudioClip explosionSound;

    public bool phaseTwo = false;
    public int platformCooldown = 3;
    public int platformNum;
    public GameObject[] platforms;
    
    void Start()
    {
        bossHealth = GetComponentInParent<Health>();
        asBoss = GetComponentInParent<AudioSource>();
        explosion = GetComponentInParent<ParticleSystem>();
        
        foreach (GameObject plat in platforms)
        {
            plat.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void Update()
    {
        if (bossHealth.healthPoints <= 15)
        {
            platformCooldown = 1;

            if (!phaseTwo)
            {
                explosion.Play();
                asBoss.PlayOneShot(explosionSound, 0.5f);

                phaseTwo = true;
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DropPlatform());
        }
    }

    IEnumerator DropPlatform()
    {
        yield return new WaitForSeconds(1);

        while (bossHealth.healthPoints > 0)
        {
            platformNum = Random.Range(0, platforms.Length);
            platformRenderer = platforms[platformNum].GetComponent<Renderer>();
            platformRenderer.material.color = Color.red;

            yield return new WaitForSeconds(platformCooldown);

            platformRenderer.material.color = Color.white;
            platforms[platformNum].SetActive(false);

            yield return new WaitForSeconds(platformCooldown);

            platforms[platformNum].SetActive(true);
        }
    }
}
