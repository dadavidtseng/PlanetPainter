using System;
using Zenject;

namespace Switch
{
    public class SwitchOutlookHandler : IInitializable, IDisposable
    {
        [Inject] private SignalBus  signalBus;
        [Inject] private SwitchView view;

        // TODO: since it's inside of player domain, refactor it to reactive instead of using signal
        public void Initialize()
        {
            signalBus.Subscribe<OnSwitchColorChanged>(OnSwitchColorChanged);
        }

        private void OnSwitchColorChanged(OnSwitchColorChanged e)
        {
            var index = (int)e.color;

            view.SetSprite(view.GetTargetSprites()[index]);
        }

        public void Dispose()
        {
            // signalBus.Unsubscribe<OnSwitchColorChanged>(OnSwitchColorChanged);
        }
    }
}