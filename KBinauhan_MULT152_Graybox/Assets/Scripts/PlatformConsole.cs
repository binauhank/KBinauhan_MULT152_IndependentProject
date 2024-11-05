using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformConsole : MonoBehaviour
{
    private bool playerIsClose = false;
    public bool activatePlatform = false;

    void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            activatePlatform = true;
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
