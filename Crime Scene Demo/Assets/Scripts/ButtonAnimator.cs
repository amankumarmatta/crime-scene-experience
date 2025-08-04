using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public float hoverScale = 1.1f;
    public float clickScale = 0.9f;
    public float animationDuration = 0.2f;

    private Vector3 originalScale;
    private Button button;

    private void Awake()
    {
        originalScale = transform.localScale;
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button != null && button.interactable)
            transform.DOScale(originalScale * hoverScale, animationDuration).SetEase(Ease.OutBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (button != null && button.interactable)
            transform.DOScale(originalScale, animationDuration).SetEase(Ease.OutBack);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (button != null && button.interactable)
        {
            Sequence clickSequence = DOTween.Sequence();
            clickSequence.Append(transform.DOScale(originalScale * clickScale, animationDuration * 0.5f).SetEase(Ease.InOutQuad));
            clickSequence.Append(transform.DOScale(originalScale * hoverScale, animationDuration * 0.5f).SetEase(Ease.OutBack));
        }
    }
}
