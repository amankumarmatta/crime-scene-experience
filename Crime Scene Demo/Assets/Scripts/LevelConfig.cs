using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "CrimeScene/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public string sceneName;
    public int timeLimitInSeconds;
    public bool useTimer;
}
