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
    }

    void OnExitButtonClicked()
    {
        SceneLoader.Instance.ExitGame();
    }

    void OnGuideButtonClicked()
    {
        
    }
}
