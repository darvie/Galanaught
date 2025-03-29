using TMPro;
using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;

    [SerializeField] private LifeCounter lifecounter;
    [SerializeField] private int point = 0;
    [SerializeField] private ScoreCounterUI scoreCounter;

    private int currentLives;

    public GameObject gameOverPanel;


    private void Start()
    {
        gameOverPanel.SetActive(false);

        currentLives = PlayerPrefs.GetInt("Lives", maxLives);  
        point = PlayerPrefs.GetInt("Score", 0);
        lifecounter.UpdateLife(currentLives);
        scoreCounter.UpdatePoint(point);
    }
    public void IncreasePoint()
    {
        Debug.Log("Increasing Point: " + point); // Check if this is being called
        point++;
        scoreCounter.UpdatePoint(point);
      //  SaveGame();

    }

   /* private void OnEnable()
    {
        InputManager.Instance.OnFire.AddListener(FireBullet);
        //bullet.ResetBullet();
        totalBrickCount = bricksContainer.childCount;
        currentBrickCount = bricksContainer.childCount;
    }

    private void OnDisable()
    {
        InputManager.Instance.OnFire.RemoveListener(FireBullet);
    }

    private void FireBullet()
    {
        bullet.FireBullet();
    }*/

  /*  public void SaveGame()
    {
        // Save the current lives and points to PlayerPrefs
        PlayerPrefs.SetInt("Lives", currentLives);
        PlayerPrefs.SetInt("Score", point);
        PlayerPrefs.Save();
    }
  */
    public void KillBullet()
    {
        currentLives--;
        lifecounter.UpdateLife(currentLives);
        Debug.Log("Life lost! Remaining lives: " + currentLives);

     //   SaveGame();

        if (currentLives <= 0)
        {
            // trigger gameover logic
            Debug.Log("Game Over!");
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
         //   StartCoroutine(EndGame());
        }
       // else
       // {
           // bullet.ResetBullet();
       // }
    }

  /*  IEnumerator EndGame()
    {
        yield return new WaitForSecondsRealtime(1.5f); // Wait for 1.5 seconds, using real time
        Time.timeScale = 1; // Reset the time scale to normal before transitioning
        SceneHandler.Instance.LoadMenuScene(); // Load the main menu scene
    }
  */
    public void ResetGame()
    {
        // Reset the lives and points, or you can reset specific values
        PlayerPrefs.DeleteKey("Lives");
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.Save();  // Ensure data is written to disk
    }
}
