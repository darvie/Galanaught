using UnityEngine;
using TMPro;

public class KillCounterManager : MonoBehaviour
{
    public static KillCounterManager Instance { get; private set; }
    public TMP_Text killCounterText;
    private int killCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseKillCount()
    {
        killCount++;
        killCounterText.text = "Kills: " + killCount;
    }
}