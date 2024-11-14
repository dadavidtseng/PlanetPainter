using System;

//TEST PERFORCE
namespace Notify
{
    public interface INotifyService
    {
        void Show(string title, string content, Action confirm = null, Action cancel = null);
        void Close();
    }
}