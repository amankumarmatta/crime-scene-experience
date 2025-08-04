using UnityEngine;

public class LobbyUIController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject welcomePanel;

    public void OnContinueClicked()
    {
        AudioManager.Instance.PlayClick();
        menuPanel.SetActive(true);
        welcomePanel.SetActive(false);
    }
}
