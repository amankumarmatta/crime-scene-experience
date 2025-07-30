using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button guideButton;


    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        guideButton.onClick.AddListener(OnGuideButtonClicked);
    }

    void OnStartButtonClicked()
    {
        SceneLoader.Instance.LoadScene("Room Select");
        AudioManager.Instance.PlayClick();
    }

    void OnExitButtonClicked()
    {
        SceneLoader.Instance.ExitGame();
        AudioManager.Instance.PlayClick();
    }

    void OnGuideButtonClicked()
    {
        AudioManager.Instance.PlayClick();
    }
}
