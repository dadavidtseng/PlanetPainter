using System;
using Audio;
using Data;
using Game;
using Misc;
using SceneTransition;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

namespace GameScene
{
    public class UI_Pause : UI_SetAppear
    {
        [Inject] private readonly SignalBus     signalBus;
        [Inject] private readonly IAudioService audioService;
        [Inject] private readonly ISceneService sceneService;
        [Inject] private readonly IGameService  gameService;
        [Inject] private readonly GameData      gameData;

        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private AudioMixer      audioMixer;
        [SerializeField] private Slider          bgmVolumeSlider;
        [SerializeField] private Slider          sfxVolumeSlider;

        private void OnEnable()
        {
            signalBus.Subscribe<OnGameStateChanged>(OnGameStateChanged);
        }

        private void OnDisable()
        {
            signalBus.Unsubscribe<OnGameStateChanged>(OnGameStateChanged);
        }

        private void Start()
        {
            titleText.text = $"Level {gameData.difficulty + 1}";
        }

        private void OnGameStateChanged(OnGameStateChanged e)
        {
            if (e.state == GameState.Pause)
                SetAppear(true);

            if (e.preState == GameState.Pause)
                SetAppear(false);
        }

        public void SetBgmVolume()
        {
            audioMixer.SetFloat("Bgm", Mathf.Log10(bgmVolumeSlider.value) * 20);
        }

        public void SetSfxVolume()
        {
            audioMixer.SetFloat("Sfx", Mathf.Log10(bgmVolumeSlider.value) * 20);
        }

        public void Button_Restart()
        {
            audioService.PlayButtonClickAudio();

            sceneService.LoadScene(3);
        }

        public void Button_LevelSelect()
        {
            audioService.PlayButtonClickAudio();

            sceneService.LoadScene(2);
        }

        public void Button_MainMenu()
        {
            audioService.PlayButtonClickAudio();

            sceneService.LoadScene(1);
        }

        public void Button_Resume()
        {
            audioService.PlayButtonClickAudio();

            gameService.ChangeState(GameState.Game);
        }
    }
}