using Menu;
using Zenject;

namespace MenuScene
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSignal();
            BindMenu();
        }

        private void BindMenu()
        {
            Container.BindInterfacesAndSelfTo<MenuService>().AsSingle();
            Container.Bind<MenuStateHandler>().AsSingle();
        }

        private void BindSignal()
        {
            Container.DeclareSignal<OnMenuStateChanged>();

            SignalBusInstaller.Install(Container);
        }
    }
}