using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace SceneTransition
{
    public class SceneView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Slider      progressBarSlider;

        public void SetAppear(bool IsOn)
        {
            canvasGroup.DOFade(IsOn ? 1 : 0, 0.5f);
            canvasGroup.interactable = canvasGroup.blocksRaycasts = IsOn;
        }

        public Slider GetProgressBarSlider() => progressBarSlider;
    }
}