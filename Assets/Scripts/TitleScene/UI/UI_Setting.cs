using Audio;
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
        [SerializeField] private Slider     volumeSlider;

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

        public void SetAudioMixerVolume(string exposedName)
        {
            audioMixer.SetFloat(exposedName, Mathf.Log10(volumeSlider.value) * 20);
        }

        public void Button_Close()
        {
            SetAppear(false);

            audioService.PlayButtonClickAudio();

            titleService.ChangeTitleState(TitleState.Title);
        }
    }
}