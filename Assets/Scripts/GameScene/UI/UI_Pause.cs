using Audio;
using Game;
using Misc;
using SceneTransition;
using Zenject;

namespace GameScene
{
    public class UI_Pause : UI_SetAppear
    {
        [Inject] private readonly SignalBus     signalBus;
        [Inject] private readonly IAudioService audioService;
        [Inject] private readonly ISceneService sceneService;
        [Inject] private readonly IGameService  gameService;

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
            if (e.state == GameState.Pause)
                SetAppear(true);

            if (e.preState == GameState.Pause)
                SetAppear(false);
        }

        public void Button_Confirm()
        {
            audioService.PlayButtonClickAudio();

            sceneService.LoadScene(2);
        }

        public void Button_Cancel()
        {
            audioService.PlayButtonClickAudio();

            gameService.ChangeState(GameState.Game);
        }
    }
}