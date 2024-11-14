using Zenject;

namespace Switch
{
    public class SwitchInstaller : Installer<SwitchInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SwitchView>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<SwitchFacade>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<SwitchColorHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<SwitchOutlookHandler>().AsSingle();
        }
    }
}