using Audio;
using Game;
using UnityEngine;
using Zenject;

namespace GameScene
{
    public class UI_Game : MonoBehaviour
    {
        [Inject] private readonly SignalBus     signalBus;
        [Inject] private readonly IAudioService audioService;

        [SerializeField] private AudioClip gameBgm;

        private void Awake()
        {
            audioService.PlayBackgroundMusic(gameBgm);
        }

        private void OnEnable()
        {
            signalBus.Subscribe<OnGameStateChanged>(OnGameStateChanged);
        }

        private void OnGameStateChanged(OnGameStateChanged e)
        {
            if (e.state == GameState.Result)
                audioService.StopBackgroundMusic();
        }
    }
}