using Audio;
using Misc;
using Title;
using Zenject;

namespace TitleScene
{
    public class UI_Credit : UI_SetAppear
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
            if (e.state == TitleState.Credit)
                SetAppear(true);
        }

        public void Button_Back()
        {
            SetAppear(false);

            audioService.PlayButtonClickAudio();

            titleService.ChangeTitleState(TitleState.Title);
        }
    }
}