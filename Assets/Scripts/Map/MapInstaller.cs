using Zenject;

namespace Map
{
    public class MapInstaller : MonoInstaller<MapInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MapService>().AsSingle();
            Container.Bind<MapView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<MapOutlookHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MapPercentageHandler>().AsSingle();
        }
    }
}