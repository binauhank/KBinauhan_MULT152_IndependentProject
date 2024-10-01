using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPlatforms : MonoBehaviour
{
    public GameObject[] platforms;
    public ThirdPersonController upgradeCheck;

    void Start()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (upgradeCheck.jumpUpgrade == true)
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].SetActive(true);
            }
        }
    }
}
