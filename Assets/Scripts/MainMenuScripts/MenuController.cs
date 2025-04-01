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

    private void Start()
    {
        // Load saved volume or default to 100% (1.0)
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("masterVolume");
            AudioListener.volume = savedVolume;
            volumeSliderValue.value = savedVolume;
        }
        else
        {
            AudioListener.volume = 1f;
            volumeSliderValue.value = 1f; // Start at 100%
        }

        // Update text value
        volumeTextValue.text = volumeSliderValue.value.ToString("0.0");

        // Listen for changes in slider value
        volumeSliderValue.onValueChanged.AddListener(SetVolume);
    }

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
        audioManager.PlayGameplayMusic();
        Debug.Log("Playing Gameplay Music");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(levelToLoad);
        audioManager.PlayGameplayMusic(); 
        Debug.Log("Playing Gameplay Music");

    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        PlayerPrefs.Save(); // Ensure changes are stored
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
