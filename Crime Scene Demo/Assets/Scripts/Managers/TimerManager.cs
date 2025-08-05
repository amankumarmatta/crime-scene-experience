using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;
    public LevelConfig[] levelConfigs;
    private float remainingTime;
    private bool timerRunning = false;
    public TextMeshProUGUI timerText;
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
        LevelConfig currentConfig = GetLevelConfigForScene(scene.name);
        if (currentConfig != null)
        {
            remainingTime = currentConfig.timeLimitInSeconds;
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
            yield return new WaitForSeconds(1f);
            remainingTime--;
            Debug.Log($"Time Left: {remainingTime}");
        }
        UpdateTimerDisplay();
        timerRunning = false;
        TimerEnded();
    }
    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60f);
            int seconds = Mathf.FloorToInt(remainingTime % 60f);
            timerText.text = $"{minutes}:{seconds}";
        }
    }
    private void TimerEnded()
    {
        Debug.Log("Time's up! Level failed.");
    }
    public float GetRemainingTime() => remainingTime;

    public void AssignTimerText(TextMeshProUGUI newTimerText)
    {
        timerText = newTimerText;
    }
}
