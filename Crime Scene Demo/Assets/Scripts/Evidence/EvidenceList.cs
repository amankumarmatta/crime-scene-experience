using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EvidenceList", menuName = "CrimeScene/EvidenceList")]
public class EvidenceList : ScriptableObject
{
    public List<string> evidenceItems;
}
