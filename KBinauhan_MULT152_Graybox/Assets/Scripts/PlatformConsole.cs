using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformConsole : MonoBehaviour
{
    private bool playerIsClose = false;
    public bool activatePlatform = false;

    private AudioSource asConsole;
    public AudioClip consoleSound;
    public AudioClip failSound;

    private ThirdPersonController upgradeCheck;

    public GameObject[] platformArray;

    void Start()
    {
        asConsole = GetComponent<AudioSource>();
        upgradeCheck = GameObject.Find("Player").GetComponent<ThirdPersonController>();
        
        foreach (GameObject platform in platformArray)
        {
            platform.SetActive(false);
        }
    }
    
    void Update()
    {
        if (upgradeCheck.hackingUpgrade && playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            activatePlatform = true;

            foreach (GameObject platform in platformArray)
            {
                platform.SetActive(true);
            }

            asConsole.PlayOneShot(consoleSound, 0.5f);
        }
        else if (!upgradeCheck.hackingUpgrade && playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            asConsole.PlayOneShot(failSound, 0.5f);
        }
    }

    void OnTriggerEnter()
    {
        playerIsClose = true;
    }

    void OnTriggerExit()
    {
        playerIsClose = false;
    }
}
