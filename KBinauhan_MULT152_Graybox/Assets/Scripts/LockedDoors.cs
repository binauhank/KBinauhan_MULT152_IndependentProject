using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoors : MonoBehaviour
{
    public GameObject lockedDoor;
    public ThirdPersonController upgradeCheck;
    public bool playerIsClose = false;

    private Animator doorAnim;

    void Start()
    {
        doorAnim = lockedDoor.GetComponent<Animator>();
    }
    
    void Update()
    {
        if (upgradeCheck.hackingUpgrade && playerIsClose && Input.GetKey(KeyCode.E))
        {
            doorAnim.SetTrigger("Door_open");
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
