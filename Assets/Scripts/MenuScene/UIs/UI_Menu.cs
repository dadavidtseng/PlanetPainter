﻿using Audio;
using Data;
using Menu;
using Misc;
using SceneTransition;
using UnityEngine;
using Zenject;

namespace MenuScene
{
    public class UI_Menu : UI_SetAppear
    {
        [Inject] private readonly SignalBus     signalBus;
        [Inject] private readonly GameData      gameData;
        [Inject] private readonly IAudioService audioService;
        [Inject] private readonly IMenuService  menuService;
        [Inject] private readonly ISceneService sceneService;

        [SerializeField] private AudioClip menuBgm;

        private void Awake()
        {
            audioService.PlayBackgroundMusic(menuBgm);
        }

        private void OnEnable()
        {
            signalBus.Subscribe<OnMenuStateChanged>(OnMenuStateChanged);
        }

        private void OnDisable()
        {
            signalBus.Unsubscribe<OnMenuStateChanged>(OnMenuStateChanged);
        }

        private void OnMenuStateChanged(OnMenuStateChanged e)
        {
            if (e.state == MenuState.StoryBoard)
                SetAppear(false);

            if (e.state == MenuState.Menu)
                SetAppear(true);
        }

        public void Button_LoadLevel(int levelIndex)
        {
            audioService.PlayButtonClickAudio();

            gameData.SetDifficulty(levelIndex);
            sceneService.LoadScene(3);
        }

        public void Button_Back()
        {
            audioService.PlayButtonClickAudio();

            sceneService.LoadScene(1);
        }

        public void Button_OpenStoryBoard()
        {
            audioService.PlayButtonClickAudio();

            menuService.ChangeMenuState(MenuState.StoryBoard);
        }
    }
}