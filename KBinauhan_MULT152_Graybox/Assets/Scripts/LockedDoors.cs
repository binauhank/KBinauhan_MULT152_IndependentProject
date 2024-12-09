using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoors : MonoBehaviour
{
    public GameObject lockedDoor;
    public ThirdPersonController upgradeCheck;
    public bool playerIsClose = false;

    private Animator doorAnim;

    private AudioSource asDoor;
    public AudioClip doorSound;
    public AudioClip failSound;

    void Start()
    {
        doorAnim = lockedDoor.GetComponent<Animator>();
        asDoor = lockedDoor.GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (upgradeCheck.hackingUpgrade && playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            doorAnim.SetTrigger("Door_open");
            asDoor.PlayOneShot(doorSound, 0.5f);
        }
        else if (!upgradeCheck.hackingUpgrade && playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            asDoor.PlayOneShot(failSound, 0.5f);
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsClose = true;
            doorAnim.SetBool("character_nearby", true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsClose = false;
            doorAnim.SetBool("character_nearby", false);
        }
    }
}
