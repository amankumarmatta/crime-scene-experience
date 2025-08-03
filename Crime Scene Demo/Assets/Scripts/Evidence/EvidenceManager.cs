using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EvidenceManager : MonoBehaviour
{
    public static EvidenceManager Instance;

    public EvidenceList evidenceListSO;
    Transform toggleParent;
    public GameObject togglePrefab;

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
        evidenceToggles.Clear();

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

    public void AssignToggleParent(Transform newParent)
    {
        toggleParent = newParent;
        foreach (Transform child in toggleParent)
        {
            Destroy(child.gameObject);
        }
        SetupToggles();
    }
}
