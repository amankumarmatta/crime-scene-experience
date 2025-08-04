using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;


    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
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
}
