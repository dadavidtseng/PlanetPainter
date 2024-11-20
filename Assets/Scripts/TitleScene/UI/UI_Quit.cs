using Audio;
using Misc;
using Title;
using UnityEngine;
using Zenject;

namespace TitleScene
{
    public class UI_Quit : UI_SetAppear
    {
        [Inject] private readonly SignalBus     signalBus;
        [Inject] private readonly IAudioService audioService;
        [Inject] private readonly ITitleService titleService;

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
            if (e.state == TitleState.Quit)
                SetAppear(true);

            if (e.preState == TitleState.Quit)
                SetAppear(false);
        }

        public void Button_Quit()
        {
            audioService.PlayButtonClickAudio();

            Application.Quit();
        }

        public void Button_Cancel()
        {
            audioService.PlayButtonClickAudio();

            titleService.ChangeTitleState(TitleState.Title);
        }
    }
}