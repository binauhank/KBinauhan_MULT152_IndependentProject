using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    private Health healthScript;

    void Start()
    {
        healthScript = GameObject.Find("Player").GetComponent<Health>();
    }

    void Update()
    {
        if (healthScript.healthPoints <= 0)
        {
            gameOver = true;
            Debug.Log("Game over!");
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Graybox");
        }
    }
}
