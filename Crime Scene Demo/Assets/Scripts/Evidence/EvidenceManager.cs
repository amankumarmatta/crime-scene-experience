using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EvidenceManager : MonoBehaviour
{
    public static EvidenceManager Instance;

    public EvidenceList evidenceListSO;
    public Transform toggleParent; // The parent panel for toggles
    public GameObject togglePrefab; // A prefab Toggle with label

    private Dictionary<string, Toggle> evidenceToggles = new Dictionary<string, Toggle>();

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

        SetupToggles();
    }

    private void SetupToggles()
    {
        foreach (var item in evidenceListSO.evidenceItems)
        {
            var toggleGO = Instantiate(togglePrefab, toggleParent);
            toggleGO.name = $"Toggle_{item}";
            var toggle = toggleGO.GetComponent<Toggle>();
            var label = toggleGO.GetComponentInChildren<Text>();
            label.text = item;

            toggle.gameObject.SetActive(false); // Hide initially
            evidenceToggles.Add(item, toggle);
        }
    }

    public void MarkEvidenceFound(string evidenceID)
    {
        if (evidenceToggles.ContainsKey(evidenceID))
        {
            var toggle = evidenceToggles[evidenceID];
            toggle.gameObject.SetActive(true);
            toggle.isOn = true;
        }
        else
        {
            Debug.LogWarning($"Evidence ID '{evidenceID}' not found in the list!");
        }
    }
}
