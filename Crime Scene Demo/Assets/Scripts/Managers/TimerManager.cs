using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;
    public LevelConfig[] levelConfigs;

    private float remainingTime;
    private bool timerRunning = false;
    private bool timerEnded = false;

    public TextMeshProUGUI timerText;
    public float gameOverDelay = 3f;

    private GameObject hudButtonGroup;

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

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        hudButtonGroup = GameObject.Find("ButtonGroup");

        if (hudButtonGroup == null)
        {
            Debug.LogWarning("HUD Button Group not found in scene. Make sure it's named 'ButtonGroup'.");
        }

        LevelConfig currentConfig = GetLevelConfigForScene(scene.name);
        if (currentConfig != null)
        {
            remainingTime = currentConfig.timeLimitInSeconds;
            timerEnded = false;
            StartCoroutine(TimerCountdown());
            Debug.Log($"Timer started for scene {scene.name}: {remainingTime} seconds");
        }
        else
        {
            Debug.Log($"No timer configured for scene: {scene.name}");
        }
    }

    private LevelConfig GetLevelConfigForScene(string sceneName)
    {
        foreach (var config in levelConfigs)
        {
            if (config.sceneName == sceneName)
                return config;
        }
        return null;
    }

    private IEnumerator TimerCountdown()
    {
        timerRunning = true;
        while (remainingTime > 0)
        {
            UpdateTimerDisplay();
            yield return new WaitForSeconds(1f);
            remainingTime--;
            Debug.Log($"Time Left: {remainingTime}");
        }

        timerRunning = false;
        TimerEnded();
    }

    private void UpdateTimerDisplay()
    {
        if (timerEnded || timerText == null)
            return;

        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void TimerEnded()
    {
        Debug.Log("Time's up! Level failed.");

        timerEnded = true;

        // Disable Buttons Group if found
        if (hudButtonGroup != null)
        {
            hudButtonGroup.SetActive(false);
        }

        if (timerText != null)
        {
            timerText.text = "Time's Up!\nReturning to Lobby...";
            timerText.fontSize = 80;
            timerText.alignment = TextAlignmentOptions.Center;
        }

        StartCoroutine(ReturnToLobbyAfterDelay());
    }

    private IEnumerator ReturnToLobbyAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
        SceneLoader.Instance.LoadScene("Lobby");
    }

    public float GetRemainingTime() => remainingTime;

    public void AssignTimerText(TextMeshProUGUI newTimerText)
    {
        timerText = newTimerText;
    }
}
