using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI timerText;
    public GameObject hudPanel;

    [Header("Level Settings")]
    public string lobbySceneName = "Lobby";

    private void Start()
    {
        SetupLevelUI();
    }

    private void SetupLevelUI()
    {
        if (timerText != null)
        {
            TimerManager.Instance.AssignTimerText(timerText);
        }
        else
        {
            Debug.LogWarning("TimerText not assigned in LevelManager.");
        }

        if (hudPanel != null)
        {
            hudPanel.SetActive(true);
        }
    }

    public void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void ExitToLobby()
    {
        SceneLoader.Instance.LoadScene(lobbySceneName);
    }
}
