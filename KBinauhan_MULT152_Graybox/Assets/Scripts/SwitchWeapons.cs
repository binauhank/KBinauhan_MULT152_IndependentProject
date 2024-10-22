using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    public GameObject pulseCannon;
    public ThirdPersonController controllerScript;

    // Start is called before the first frame update
    void Start()
    {
        pulseCannon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pulseCannon.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && controllerScript.cannonUpgrade)
        {
            pulseCannon.SetActive(true);
        }
    }
}
