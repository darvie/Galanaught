using UnityEngine;
using TMPro;

public class GameClockController : MonoBehaviour
{
    [Header("Clock UI")]
    [SerializeField] private TMP_Text clockText;
    private float elapsedTime;

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateClockUI();
    }

    void UpdateClockUI()
    {
        int hours = Mathf.FloorToInt(elapsedTime / 3600f);
        int minutes = Mathf.FloorToInt((elapsedTime - hours * 3600f) / 60f);
        int seconds = Mathf.FloorToInt((elapsedTime - hours * 3600f) - minutes * 60f);

        string clockString = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        clockText.text = clockString;
    }
}