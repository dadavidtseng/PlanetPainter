using System;
using Zenject;

//TEST
namespace Notify
{
    public class NotifyService : INotifyService
    {
        [Inject] private readonly NotifyView view;

        public void Show(string title, string content, Action confirm = null, Action cancel = null)
            => view.SetContent(title, content, confirm, cancel);

        public void Close() => view.SetAppear(false);
    }
}