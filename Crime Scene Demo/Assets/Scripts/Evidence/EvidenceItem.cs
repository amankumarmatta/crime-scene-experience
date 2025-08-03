using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EvidenceItem : MonoBehaviour
{
    public string evidenceID;

    private XRBaseInteractable interactable;

    void Awake()
    {
        Debug.Log("EvidenceItem script attached to: " + gameObject.name);
        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnSelected);
    }

    private void OnSelected(SelectEnterEventArgs args)
    {
        Debug.Log($"Selected evidence: {evidenceID}");
        EvidenceManager.Instance.MarkEvidenceFound(evidenceID);
    }
}
