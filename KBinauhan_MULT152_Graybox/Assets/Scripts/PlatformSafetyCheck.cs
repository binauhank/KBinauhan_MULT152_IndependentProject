using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSafetyCheck : MonoBehaviour
{
    public bool isSafe = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isSafe = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isSafe = true;
        }
    }
}
