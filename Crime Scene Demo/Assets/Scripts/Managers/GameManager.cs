using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Dictionary<string, Toggle> evidenceToggles = new Dictionary<string, Toggle>();

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
    }

    public void RegisterToggle(string id, Toggle toggle)
    {
        if (!evidenceToggles.ContainsKey(id))
        {
            evidenceToggles.Add(id, toggle);
        }
    }

    public void MarkEvidenceFound(string id)
    {
        if (Instance == null)
        {
            Debug.LogWarning("GameManager is not initialized!");
            return;
        }

        if (evidenceToggles.ContainsKey(id))
        {
            evidenceToggles[id].isOn = true;
            Debug.Log($"{id} evidence found!");
        }
    }
}
