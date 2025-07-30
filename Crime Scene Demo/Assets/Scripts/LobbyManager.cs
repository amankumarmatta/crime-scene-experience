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
        SceneManager.LoadSceneAsync(1);
    }

    void OnExitButtonClicked()
    {
        // Logic to exit the game
        Debug.Log("Exit button clicked. Exiting the game...");
        Application.Quit();
    }

    void OnGuideButtonClicked()
    {
        // Logic to show the game guide
        Debug.Log("Guide button clicked. Showing the game guide...");
        // Add your guide showing logic here
    }
}
