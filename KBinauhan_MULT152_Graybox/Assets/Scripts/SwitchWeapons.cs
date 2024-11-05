using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    private GameManager gameMg;
    
    public GameObject pulseCannon;
    public ThirdPersonController controllerScript;

    void Start()
    {
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        pulseCannon.SetActive(false);
    }

    void Update()
    {
        if (!gameMg.gameOver)
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
}
