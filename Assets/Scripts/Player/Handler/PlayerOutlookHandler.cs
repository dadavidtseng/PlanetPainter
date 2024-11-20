using System;
using Zenject;

namespace Player
{
    public class PlayerOutlookHandler : IInitializable, IDisposable
    {
        [Inject] private SignalBus  signalBus;
        [Inject] private PlayerView view;

        // TODO: since it's inside of player domain, refactor it to reactive instead of using signal
        public void Initialize()
        {
            signalBus.Subscribe<OnPlayerColorChanged>(OnPlayerColorChanged);
        }

        private void OnPlayerColorChanged(OnPlayerColorChanged e)
        {
            
        }

        public void Dispose()
        {
            signalBus.Unsubscribe<OnPlayerColorChanged>(OnPlayerColorChanged);
        }
    }
}