using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootloader : MonoBehaviour
{
    [SerializeField] private string lobbySceneName = "Lobby";

    void Start()
    {
        SceneLoader.Instance.LoadScene(lobbySceneName);
    }
}
