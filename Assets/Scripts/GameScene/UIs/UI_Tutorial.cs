using Audio;
using Game;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameScene
{
    public class UI_Tutorial : MonoBehaviour
    {
        [Inject] private readonly IAudioService audioService;
        [Inject] private readonly IGameService  gameService;

        [SerializeField] private CanvasGroup     canvasGroup;
        [SerializeField] private RectTransform   groupTrans;
        [SerializeField] private Image           tutorialImg;
        [SerializeField] private TextMeshProUGUI tutorialText;
        [SerializeField] private Sprite[]        tutorialSprites;
        [SerializeField] private string[]        tutorialContent;
        [SerializeField] private TextMeshProUGUI lastBtnText;
        [SerializeField] private TextMeshProUGUI nextBtnText;

        private int progress;

        private void Start()
        {
            SetAppear(true);
        }

        public void Button_ChangePage(int delta)
        {
            audioService.PlayButtonClickAudio();

            progress += delta;

            if (progress is -1 or 7)
            {
                SetAppear(false);
                gameService.ChangeState(GameState.Game);
                return;
            }

            tutorialImg.sprite = tutorialSprites[progress];
            // tutorialImg.SetNativeSize();
            tutorialText.text = tutorialContent[progress];

            SetButtonText();
        }
        
        //  TODO: BUG FIX
        private void SetButtonText()
        {
            lastBtnText.text = progress == 0 ? "Skip Tutorial" : "Previous Page";
            nextBtnText.text = progress == 6 ? "Finish Tutorial" : "Next Page";
        }

        private void SetAppear(bool IsOn)
        {
            var targetScale = IsOn ? Vector2.one : Vector2.zero;
            var duration    = IsOn ? 0.5f : 0.3f;
            var ease        = IsOn ? Ease.OutElastic : Ease.OutCubic;

            canvasGroup.interactable = canvasGroup.blocksRaycasts = IsOn;

            canvasGroup.DOKill();
            groupTrans.DOKill();

            canvasGroup.DOFade(IsOn ? 1 : 0, 0.2f);

            groupTrans.DOScale(targetScale, duration)
                      .SetEase(ease);
        }
    }
}
