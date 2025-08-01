using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Toggle brushToggle;
    public Toggle cleanerToggle;

    void Start()
    {
        GameManager.Instance.RegisterToggle("Brush", brushToggle);
        GameManager.Instance.RegisterToggle("Cleaner", cleanerToggle);
    }
}
