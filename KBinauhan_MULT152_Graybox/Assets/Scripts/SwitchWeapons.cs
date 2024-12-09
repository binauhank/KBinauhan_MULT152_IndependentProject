using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    private GameManager gameMg;
    
    public ThirdPersonController controllerScript;

    public bool canPunch = true;
    public bool canShoot = false;

    void Start()
    {
        gameMg = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (!gameMg.gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                canPunch = true;
                canShoot = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && controllerScript.cannonUpgrade)
            {
                canPunch = false;
                canShoot = true;
            }
        }
    }
}
