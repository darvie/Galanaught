using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSliderValue = null;
    [SerializeField] private GameObject confirmationPrompt = null;
    
    public string _newGameLevel;
    private string levelToLoad;
    public AudioManager audioManager;


    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(levelToLoad);
        audioManager.PlayGameplayMusic(); 

    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
            StartCoroutine(confirmationBoX());
    }

    public IEnumerator confirmationBoX()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }

    public void QuitGame()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
