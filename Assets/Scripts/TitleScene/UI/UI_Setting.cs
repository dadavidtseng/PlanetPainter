using Audio;
using Game;
using Menu;
using Misc;
using Title;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

namespace TitleScene
{
    public class UI_Setting : UI_SetAppear
    {
        [Inject] private readonly SignalBus     signalBus;
        [Inject] private readonly IAudioService audioService;
        [Inject] private readonly ITitleService titleService;

        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider     bgmVolumeSlider;
        [SerializeField] private Slider     sfxVolumeSlider;

        private void OnEnable()
        {
            signalBus.Subscribe<OnTitleStateChanged>(OnTitleStateChanged);
        }

        private void OnDisable()
        {
            signalBus.Unsubscribe<OnTitleStateChanged>(OnTitleStateChanged);
        }

        private void OnTitleStateChanged(OnTitleStateChanged e)
        {
            if (e.state == TitleState.Setting)
                SetAppear(true);
        }

        public void SetBgmVolume()
        {
            audioMixer.SetFloat("Bgm", Mathf.Log10(bgmVolumeSlider.value) * 20);
        }
        
        public void SetSfxVolume()
        {
            audioMixer.SetFloat("Sfx", Mathf.Log10(bgmVolumeSlider.value) * 20);
        }

        public void Button_Close()
        {
            SetAppear(false);

            audioService.PlayButtonClickAudio();

            titleService.ChangeTitleState(TitleState.Title);
        }
    }
}