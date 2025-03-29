using UnityEditor.Rendering;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
       
    }
    
    public void TogglePause()
    {
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
        pauseMenu.SetActive(true);  
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        CloseAllMenus();
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void CloseAllMenus()
    {
        pauseMenu.SetActive(false);
       
    }

}
