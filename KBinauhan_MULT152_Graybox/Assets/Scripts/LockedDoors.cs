using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoors : MonoBehaviour
{
    public GameObject lockedDoor;
    public ThirdPersonController upgradeCheck;
    public bool playerIsClose = false;

    void Update()
    {
        if (upgradeCheck.hackingUpgrade && playerIsClose && Input.GetKey(KeyCode.E))
        {
            lockedDoor.SetActive(false);
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsClose = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsClose = false;
        }
    }
}
