using Audio;
using Data;
using DG.Tweening;
using SceneTransition;
using Title;
using UnityEngine;
using Zenject;

namespace TitleScene
{
    public class UI_Title : MonoBehaviour
    {
        [Inject] private readonly ISceneService sceneService;
        [Inject] private readonly IAudioService audioService;
        [Inject] private readonly ITitleService titleService;
        [Inject] private readonly GameData      gameData;

        [SerializeField] private RectTransform startBtnRectTrans;
        [SerializeField] private RectTransform quitBtnRectTrans;
        [SerializeField] private RectTransform settingsBtnRectTrans;
        [SerializeField] private RectTransform creditsBtnRectTrans;

        [SerializeField] private AudioClip startSceneBgm;

        private void Awake()
        {
            audioService.PlayBackgroundMusic(startSceneBgm);
        }

        private void Start()
        {
            if (gameData.difficulty == 7)
            {
                titleService.ChangeTitleState(TitleState.Credit);
                gameData.SetDifficulty(8);
            }

            startBtnRectTrans.DOAnchorPosY(startBtnRectTrans.anchoredPosition.y + 10f, 1f)
                             .SetLoops(-1, LoopType.Yoyo)
                             .SetEase(Ease.InOutSine);
        }

        public void Button_Start()
        {
            audioService.PlayButtonClickAudio();

            sceneService.LoadScene(2);
        }

        public void Button_Quit()
        {
            audioService.PlayButtonClickAudio();

            quitBtnRectTrans.DOShakeAnchorPos(0.3f, 10f, 20, 90, false, true)
                            .OnComplete(() => titleService.ChangeTitleState(TitleState.Quit));
        }

        public void Button_Setting()
        {
            audioService.PlayButtonClickAudio();

            settingsBtnRectTrans.DOShakeAnchorPos(0.3f, 10f, 20, 90, false, true)
                                .OnComplete(() => titleService.ChangeTitleState(TitleState.Setting));
        }

        public void Button_Credit()
        {
            audioService.PlayButtonClickAudio();

            creditsBtnRectTrans.DOShakeAnchorPos(0.3f, 10f, 20, 90, false, true)
                               .OnComplete(() => titleService.ChangeTitleState(TitleState.Credit));
        }
    }
}