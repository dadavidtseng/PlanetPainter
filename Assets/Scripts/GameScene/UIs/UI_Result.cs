using Audio;
using Data;
using DG.Tweening;
using Game;
using Map;
using Misc;
using SceneTransition;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameScene
{
    public class UI_Result : UI_SetAppear
    {
        [Inject] private readonly SignalBus     signalBus;
        [Inject] private readonly GameData      gameData;
        [Inject] private readonly IAudioService audioService;
        [Inject] private readonly ISceneService sceneService;
        [Inject] private readonly MapRepository mapRepository;

        [SerializeField] private TextMeshProUGUI resultText;
        [SerializeField] private Image[]         starImages;
        [SerializeField] private AudioClip       resultSound;
        [SerializeField] private AudioClip       resultMushroomSound;
        [SerializeField] private AudioSource     resultAudioSource;
        [SerializeField] private AudioSource     resultMushroomAudioSource;
        [SerializeField] private Button          nextLevelBtn;

        private void OnEnable()
        {
            signalBus.Subscribe<OnGameStateChanged>(OnGameStateChanged);
        }

        private void OnDisable()
        {
            signalBus.Unsubscribe<OnGameStateChanged>(OnGameStateChanged);
        }
        
        private void OnGameStateChanged(OnGameStateChanged e)
        {
            if (e.state == GameState.Result)
            {
                if (gameData.difficulty == 7)
                    nextLevelBtn.interactable = false;

                DOTween.Sequence()
                       .AppendInterval(2.0f)
                       .AppendCallback(SetGameResult)
                       .JoinCallback(() => SetAppear(true));

                audioService.PlayOneShotAudio(resultAudioSource, resultSound);
            }
            else if (e.preState == GameState.Result)
            {
                SetAppear(false);
                // audioService.PlayOneShotAudio(popAudioSource, popOutAudioClip);
            }
        }

        private void SetGameResult()
        {
            var paintPercentage = mapRepository.GetMapService().GetPaintPercentage();
//TODO: ADD LEVEL NAME
            resultText.text = $"Your total paint percentage is\n{paintPercentage}%";

            if (paintPercentage > 90)
            {
                DOTween.Sequence()
                       .AppendInterval(1.0f)
                       .AppendCallback(() =>
                                       {
                                           starImages[0].DOFade(1.0f, 0.5f);
                                           starImages[1].DOFade(1.0f, 0.5f);
                                           starImages[2].DOFade(1.0f, 0.5f);
                                           starImages[0].transform.DOScale(1.0f, 0.5f).SetEase(Ease.OutBounce);
                                           starImages[1].transform.DOScale(1.0f, 0.5f).SetEase(Ease.OutBounce);
                                           starImages[2].transform.DOScale(1.0f, 0.5f).SetEase(Ease.OutBounce);
                                           audioService.PlayOneShotAudio(resultMushroomAudioSource, resultMushroomSound);
                                       });
            }

            if (paintPercentage > 60)
            {
                DOTween.Sequence()
                       .AppendInterval(1.0f)
                       .AppendCallback(() =>
                                       {
                                           starImages[0].DOFade(1.0f, 0.5f);
                                           starImages[1].DOFade(1.0f, 0.5f);
                                           starImages[0].transform.DOScale(1.0f, 0.5f).SetEase(Ease.OutBounce);
                                           starImages[1].transform.DOScale(1.0f, 0.5f).SetEase(Ease.OutBounce);
                                           audioService.PlayOneShotAudio(resultMushroomAudioSource, resultMushroomSound);
                                       });
            }

            if (paintPercentage > 30)
            {
                DOTween.Sequence()
                       .AppendInterval(1.0f)
                       .AppendCallback(() =>
                                       {
                                           starImages[0].DOFade(1.0f, 0.5f);
                                           starImages[0].transform.DOScale(1.0f, 0.5f).SetEase(Ease.OutBounce);
                                           audioService.PlayOneShotAudio(resultMushroomAudioSource, resultMushroomSound);
                                       });
            }
        }

        public void Button_BackToMenu()
        {
            audioService.PlayButtonClickAudio();

            sceneService.LoadScene(2);
        }

        public void Button_Restart()
        {
            audioService.PlayButtonClickAudio();

            sceneService.LoadScene(3);
        }

        public void Button_NextLevel()
        {
            audioService.PlayButtonClickAudio();

            Debug.Log($"<color=#ff0000><b>GAME DATA | difficulty: {gameData.difficulty}</b></color>");

            gameData.SetDifficulty(gameData.difficulty + 1);
            sceneService.LoadScene(3);

            Debug.Log($"<color=#ff0000><b>GAME DATA | difficulty: {gameData.difficulty}</b></color>");
        }
    }
}