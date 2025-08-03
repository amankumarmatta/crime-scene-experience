using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    public GameObject fadeCanvasPrefab;
    private Animator fadeAnimator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (fadeCanvasPrefab != null && fadeAnimator == null)
        {
            var canvas = Instantiate(fadeCanvasPrefab);
            DontDestroyOnLoad(canvas);
            fadeAnimator = canvas.GetComponentInChildren<Animator>();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (fadeAnimator == null)
        {
            fadeAnimator = FindObjectOfType<Animator>();
        }

        var timerTextObj = GameObject.Find("TimerText");
        var togglePanel = GameObject.Find("TogglePanel")?.transform;

        if (togglePanel != null && EvidenceManager.Instance != null)
        {
            EvidenceManager.Instance.AssignToggleParent(togglePanel);
            Debug.Log($"Toggle Panel assigned for scene: {scene.name}");
        }
        else
        {
            Debug.LogWarning($"Toggle Panel not found in scene: {scene.name}");
        }

        FadeInScene();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    public void ExitGame()
    {
        if (fadeAnimator != null)
        {
            fadeAnimator.SetTrigger("FadeOut");
        }
        Application.Quit();
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    public void FadeInScene()
    {
        if (fadeAnimator != null)
        {
            fadeAnimator.SetTrigger("FadeIn");
        }
    }
}
