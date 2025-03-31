using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;


public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

     void Update()
    {
        
    }

    public void TogglePause()
    {
        Debug.Log("TogglePause called");
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        AudioListener.pause = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        AudioListener.pause = false; // Resume audio

    }
    public void LoadMainMenu()
    {
        Debug.Log("Loading Main Menu");
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
}
