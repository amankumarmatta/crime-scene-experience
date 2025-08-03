using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "CrimeScene/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public string sceneName;
    public float timeLimitInSeconds;
}
