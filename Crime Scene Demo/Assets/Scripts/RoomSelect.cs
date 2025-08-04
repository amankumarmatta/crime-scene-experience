using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSelect : MonoBehaviour
{
    [SerializeField] private Button easyBtn;
    [SerializeField] private Button mediumBtn;
    [SerializeField] private Button hardBtn;

    private void Start()
    {
        easyBtn.onClick.AddListener(() => OnDifficultySelected("Easy"));
        mediumBtn.onClick.AddListener(() => OnDifficultySelected("Medium"));
        hardBtn.onClick.AddListener(() => OnDifficultySelected("Hard"));
    }

    private void OnDifficultySelected(string difficulty)
    {
        Debug.Log($"Selected difficulty: {difficulty}");

        if (difficulty == "Easy")
        {
            AudioManager.Instance.PlayClick();
            Debug.Log("Easy difficulty selected.");
            SceneLoader.Instance.LoadScene("Room 1");
        }
        else if (difficulty == "Medium")
        {
            AudioManager.Instance.PlayClick();
            Debug.Log("Medium difficulty selected.");
            SceneLoader.Instance.LoadScene("Room 2");
        }
        else if (difficulty == "Hard")
        {
            AudioManager.Instance.PlayClick();
            Debug.Log("Hard difficulty selected.");
            SceneLoader.Instance.LoadScene("Room 3");
        }
    }
}
