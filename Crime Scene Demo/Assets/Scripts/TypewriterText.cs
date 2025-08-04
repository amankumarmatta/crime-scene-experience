using UnityEngine;
using TMPro;
using System.Collections;
using DG.Tweening;

public class TypewriterText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    [TextArea] public string fullText;
    public float typingSpeed = 0.05f;

    public CanvasGroup continueButtonGroup;

    private void Start()
    {
        continueButtonGroup.alpha = 0f;
        continueButtonGroup.gameObject.SetActive(false);
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        textComponent.text = "";

        foreach (char c in fullText)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueButtonGroup.gameObject.SetActive(true);
        continueButtonGroup.DOFade(1f, 2f).SetEase(Ease.OutQuad);
    }
}
