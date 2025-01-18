using System;
using Audio;
// using Audio;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Notify
{
    public class NotifyView : MonoBehaviour
    {
        [Inject] private readonly IAudioService audioService;

        [SerializeField] private CanvasGroup   canvasGroup;
        [SerializeField] private RectTransform groupTrans;

        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI contentText;
        [SerializeField] private GameObject      buttonGroupObj;
        [SerializeField] private Button          confirmBtn;
        [SerializeField] private Button          cancelBtn;

        [SerializeField] private AudioSource popAudioSource;
        [SerializeField] private AudioClip       popInAudioClip;
        [SerializeField] private AudioClip       popOutAudioClip;

        private bool isShow;


        public void SetContent(string title, string content, Action confirmAction = null, Action cancelAction = null)
        {
            audioService.PlayButtonClickAudio();

            titleText.text   = title;
            contentText.text = content;

            buttonGroupObj.SetActive(confirmAction != null || cancelAction != null);

            confirmBtn.gameObject.SetActive(confirmAction != null);
            cancelBtn.gameObject.SetActive(cancelAction   != null);

            if (confirmAction != null)
                SetButtonListener(confirmBtn, confirmAction);

            if (cancelAction != null)
                SetButtonListener(cancelBtn, cancelAction);


            SetAppear(true);
        }

        private void SetButtonListener(Button button, Action action)
        {
            button.onClick.RemoveAllListeners();

            button.onClick.AddListener(() =>
                                       {
                                           SetAppear(false);
                                           action.Invoke();
                                       });
        }

        public async void SetAppear(bool IsOn)
        {
            var targetScale = IsOn ? Vector2.one : Vector2.zero;
            var duration    = IsOn ? 0.5f : 0.3f;
            var ease        = IsOn ? Ease.OutElastic : Ease.OutCubic;

            canvasGroup.interactable = canvasGroup.blocksRaycasts = IsOn;

            canvasGroup.DOKill();
            groupTrans.DOKill();

            audioService.PlayButtonClickAudio();

            if (IsOn)
            {
                audioService.PlayOneShotAudio(popAudioSource, popInAudioClip);

                canvasGroup.DOFade(1f, 0f);

                if (isShow)
                {
                    groupTrans.DOScale(Vector2.zero, 0.3f)
                              .SetEase(Ease.OutCubic);

                    await UniTask.Delay(300);
                }

                groupTrans.DOScale(targetScale, duration)
                          .SetEase(ease);

                isShow = true;
            }
            else
            {
                // audioService.PlayOneShotAudio(popAudioSource, popOutAudioClip);

                canvasGroup.DOFade(0f, 1f);

                groupTrans.DOScale(targetScale, duration)
                          .SetEase(ease);

                isShow = false;
            }
        }
    }
}