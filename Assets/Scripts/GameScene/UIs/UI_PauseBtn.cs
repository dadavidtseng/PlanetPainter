using Audio;
using Game;
using MainCamera;
using Notify;
using SceneTransition;
using UnityEngine;
using Zenject;

namespace GameScene
{
    public class UI_PauseBtn : MonoBehaviour
    {
        [Inject] private readonly IGameService  gameService;
        [Inject] private readonly ISceneService sceneService;
        [Inject] private readonly IAudioService audioService;

        public void Button_Back()
        {
            if (gameService.GetGameState() != GameState.Game)
                return;
            
            
            audioService.PlayButtonClickAudio();

            gameService.ChangeState(GameState.Pause);
        }
    }
}