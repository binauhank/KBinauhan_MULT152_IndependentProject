using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;

    private Health healthScript;
    private ThirdPersonController player;

    public Image[] hearts;
    public GameObject fistIcon;
    public GameObject blastIcon;
    public GameObject bootUpgradeIcon;
    public GameObject blastUpgradeIcon;
    public GameObject moduleUpgradeIcon;

    void Start()
    {
        healthScript = GameObject.Find("Player").GetComponent<Health>();
        player = GameObject.Find("Player").GetComponent<ThirdPersonController>();

        fistIcon.gameObject.SetActive(true);
        blastIcon.gameObject.SetActive(false);
    }

    void Update()
    {
        if (healthScript.healthPoints <= 0)
        {
            gameOver = true;
            Debug.Log("Game over!");
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < healthScript.healthPoints)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            fistIcon.gameObject.SetActive(true);
            blastIcon.gameObject.SetActive(false);
        }

        if (player.cannonUpgrade && Input.GetKeyDown(KeyCode.Alpha2))
        {
            fistIcon.gameObject.SetActive(false);
            blastIcon.gameObject.SetActive(true);
        }

        if (player.jumpUpgrade)
        {
            bootUpgradeIcon.gameObject.SetActive(true);
        }

        if (player.cannonUpgrade)
        {
            blastUpgradeIcon.gameObject.SetActive(true);
        }

        if (player.hackingUpgrade)
        {
            moduleUpgradeIcon.gameObject.SetActive(true);
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Graybox");
        }
    }
}
