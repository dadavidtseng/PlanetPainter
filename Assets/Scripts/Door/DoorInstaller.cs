using Zenject;

namespace Door
{
    public class DoorInstaller : Installer<DoorInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<DoorView>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<DoorFacade>().FromComponentsInHierarchy().AsSingle();
        }
    }
}