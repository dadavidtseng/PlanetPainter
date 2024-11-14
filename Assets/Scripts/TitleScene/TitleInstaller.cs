using Title;
using Zenject;

namespace TitleScene
{
    public class TitleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSignal();
            BindTitle();
        }

        private void BindTitle()
        {
            Container.BindInterfacesAndSelfTo<TitleService>().AsSingle();
            Container.Bind<TitleStateHandler>().AsSingle();
        }

        private void BindSignal()
        {
            Container.DeclareSignal<OnTitleStateChanged>();

            SignalBusInstaller.Install(Container);
        }
    }
}