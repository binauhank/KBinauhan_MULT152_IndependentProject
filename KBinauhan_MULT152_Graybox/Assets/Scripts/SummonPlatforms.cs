using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPlatforms : MonoBehaviour
{
    public GameObject[] platforms;
    public ThirdPersonController upgradeCheck;

    void Start()
    {
        foreach (GameObject platform in platforms)
        {
            platform.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (upgradeCheck.jumpUpgrade == true)
        {
            foreach (GameObject platform in platforms)
            {
                platform.SetActive(true);
            }
        }
    }
}
