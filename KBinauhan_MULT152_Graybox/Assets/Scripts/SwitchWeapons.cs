using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    public GameObject[] weapons;
    public ThirdPersonController controllerScript;

    // Start is called before the first frame update
    void Start()
    {
        weapons[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && controllerScript.cannonUpgrade)
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
        }
    }
}
