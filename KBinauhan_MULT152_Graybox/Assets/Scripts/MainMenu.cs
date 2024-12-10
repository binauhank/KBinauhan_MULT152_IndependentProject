using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject instructionScreen;

    private AudioSource asMenu;
    public AudioClip startSound;
    public AudioClip instructionSound;
    public AudioClip instructionLeaveSound;
    public AudioClip exitSound;

    void Start()
    {
        asMenu = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        Invoke("LoadGame", 0.5f);

        asMenu.PlayOneShot(startSound);
    }

    public void ShowInstructions()
    {
        titleScreen.gameObject.SetActive(false);
        instructionScreen.gameObject.SetActive(true);

        asMenu.PlayOneShot(instructionSound);
    }

    public void BackToMainMenu()
    {
        titleScreen.gameObject.SetActive(true);
        instructionScreen.gameObject.SetActive(false);

        asMenu.PlayOneShot(instructionLeaveSound);
    }

    public void ExitGame()
    {
        Invoke("CloseApplication", 0.5f);

        asMenu.PlayOneShot(exitSound);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Graybox");
    }

    void CloseApplication()
    {
        Application.Quit();
    }
}
