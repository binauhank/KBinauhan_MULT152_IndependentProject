using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    private AudioSource asWin;
    public AudioClip menuButtonSound;

    void Start()
    {
        asWin = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.None;
    }

    public void MainMenu()
    {
        Invoke("BackToMainMenu", 1f);

        asWin.PlayOneShot(menuButtonSound);
    }

    void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
