using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Renderer platformRenderer;
    private GameManager gameMg;
    private Health bossHealth;
    private AudioSource asBoss;
    private ParticleSystem explosion;
    private Animator bossAnim;

    public AudioClip explosionSound;

    public bool phaseTwo = false;
    private float platformCooldown = 3f;
    private int platformNum;
    public GameObject[] platforms;
    
    void Start()
    {
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();
        bossHealth = GetComponentInParent<Health>();
        asBoss = GetComponentInParent<AudioSource>();
        explosion = GetComponentInParent<ParticleSystem>();
        bossAnim = GetComponentInParent<Animator>();
        
        foreach (GameObject plat in platforms)
        {
            plat.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void Update()
    {
        if (bossHealth.healthPoints <= 6)
        {
            platformCooldown = 1.5f;

            if (!phaseTwo)
            {
                explosion.Play();
                asBoss.PlayOneShot(explosionSound, 0.5f);

                phaseTwo = true;
            }
        }

        if (bossHealth.healthPoints <= 0)
        {
            bossAnim.SetTrigger("Death_trig");
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

        while (bossHealth.healthPoints > 0 && !gameMg.gameOver)
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
