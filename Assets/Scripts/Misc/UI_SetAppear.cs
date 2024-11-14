using DG.Tweening;
using UnityEngine;

namespace Misc
{
    public class UI_SetAppear : MonoBehaviour
    {
        [SerializeField] private CanvasGroup   canvasGroup;
        [SerializeField] private RectTransform groupTrans;

        protected void SetAppear(bool IsOn)
        {
            canvasGroup.DOKill();
            groupTrans.DOKill();

            var targetScale = IsOn ? Vector2.one : Vector2.zero;
            var duration    = IsOn ? 0.5f : 0.3f;
            var ease        = IsOn ? Ease.OutElastic : Ease.OutCubic;

            canvasGroup.DOFade(IsOn ? 1 : 0, duration);
            canvasGroup.interactable   = IsOn;
            canvasGroup.blocksRaycasts = IsOn;

            groupTrans.DOScale(targetScale, duration)
                      .SetEase(ease);
        }
    }
}