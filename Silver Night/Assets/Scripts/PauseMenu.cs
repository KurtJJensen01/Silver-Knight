using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controlsMenu;
    public GameObject pauseButtons;
    public GameObject restartButtons;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (StaticVariables.isPaused == true && controlsMenu.activeInHierarchy == false)
            {
                ResumeGame();
            }
            else if (StaticVariables.isPaused == true && controlsMenu.activeInHierarchy == true)
            {
                pauseButtons.SetActive(true);
                controlsMenu.SetActive(false);
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; //freezes the game
        StaticVariables.isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; //resumes the game
        StaticVariables.isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        StaticVariables.playerMaxHealth = 100;
        ResumeGame();
        SceneManager.LoadScene(1);
    }
}
