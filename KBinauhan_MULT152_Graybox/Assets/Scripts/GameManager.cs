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
    public GameObject bootUpgradeIconActive;
    public GameObject blastUpgradeIconActive;
    public GameObject moduleUpgradeIconActive;

    public GameObject loseScreen;

    private AudioSource asMain;
    public AudioClip tryAgainSound;
    public AudioClip mainMenuSound;

    void Start()
    {
        healthScript = GameObject.Find("Player").GetComponent<Health>();
        player = GameObject.Find("Player").GetComponent<ThirdPersonController>();
        asMain = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        fistIcon.gameObject.SetActive(true);
        blastIcon.gameObject.SetActive(false);
        loseScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (healthScript.healthPoints <= 0)
        {
            gameOver = true;

            Invoke("LoseGame", 3f);
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
            bootUpgradeIcon.gameObject.SetActive(false);
            bootUpgradeIconActive.gameObject.SetActive(true);
        }

        if (player.cannonUpgrade)
        {
            blastUpgradeIcon.gameObject.SetActive(false);
            blastUpgradeIconActive.gameObject.SetActive(true);
        }

        if (player.hackingUpgrade)
        {
            moduleUpgradeIcon.gameObject.SetActive(false);
            moduleUpgradeIconActive.gameObject.SetActive(true);
        }
    }

    void LoseGame()
    {
        loseScreen.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void TryAgain()
    {
        Invoke("Restart", 1f);
        asMain.PlayOneShot(tryAgainSound);
    }

    void Restart()
    {
        SceneManager.LoadScene("Graybox");
    }

    public void MainMenu()
    {
        Invoke("ExitToMenu", 1f);
        asMain.PlayOneShot(mainMenuSound);
    }

    void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
