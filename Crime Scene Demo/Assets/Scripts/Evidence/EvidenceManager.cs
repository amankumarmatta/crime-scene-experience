using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EvidenceManager : MonoBehaviour
{
    public static EvidenceManager Instance;

    public EvidenceList evidenceListSO;
    public Transform toggleParent;
    public GameObject togglePrefab;

    private Dictionary<string, Toggle> evidenceToggles = new Dictionary<string, Toggle>();

    private bool isStaticScene = false;

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

    public void AssignToggleParent(Transform newParent)
    {
        toggleParent = newParent;

        string currentScene = SceneManager.GetActiveScene().name;
        isStaticScene = currentScene == "Room 1";

        evidenceToggles.Clear();

        if (isStaticScene)
        {
            RegisterStaticToggles();
        }
        else
        {
            // Clear Panel for dynamic scenes
            foreach (Transform child in toggleParent)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void RegisterStaticToggles()
    {
        Toggle[] toggles = toggleParent.GetComponentsInChildren<Toggle>();

        foreach (Toggle toggle in toggles)
        {
            string itemName = toggle.GetComponentInChildren<Text>().text;
            evidenceToggles[itemName] = toggle;
            toggle.isOn = false;
        }
    }

    public void MarkEvidenceFound(string evidenceID)
    {
        if (evidenceToggles.ContainsKey(evidenceID))
        {
            // Static Scene Toggle Found → Turn ON
            var toggle = evidenceToggles[evidenceID];
            toggle.isOn = true;
        }
        else if (!isStaticScene)
        {
            // Dynamic Scene → Create Toggle on-the-fly
            var toggleGO = Instantiate(togglePrefab, toggleParent);
            toggleGO.name = $"Toggle_{evidenceID}";
            var toggle = toggleGO.GetComponent<Toggle>();
            var label = toggleGO.GetComponentInChildren<Text>();
            label.text = evidenceID;

            toggle.isOn = true;
            evidenceToggles[evidenceID] = toggle;
        }
        else
        {
            Debug.LogWarning($"Evidence ID '{evidenceID}' not found in Room 1 toggles!");
        }
    }
}
