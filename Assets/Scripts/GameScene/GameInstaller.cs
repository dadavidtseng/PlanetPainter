using Door;
using Game;
using MainCamera;
using Map;
using Player;
using Switch;
using UnityEngine;
using Zenject;

namespace GameScene
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject doorPrefab;
        [SerializeField] private GameObject switchPrefab;

        public override void InstallBindings()
        {
            BindSignal();
            BindMap();
            BindDoor();
            BindSwitch();
            BindPlayer();
            BindGame();
            BindCamera();
        }

        private void BindCamera()
        {
            Container.BindInterfacesAndSelfTo<CameraService>().AsSingle();
            Container.Bind<CameraView>().FromComponentInHierarchy().AsSingle();
        }
        
        private void BindSignal()
        {
            Container.DeclareSignal<OnPlayerStateChanged>();
            Container.DeclareSignal<OnPlayerColorChanged>();
            Container.DeclareSignal<OnSwitchColorChanged>();
            Container.DeclareSignal<OnGameStateChanged>();

            SignalBusInstaller.Install(Container);
        }

        private void BindGame()
        {
            Container.BindInterfacesAndSelfTo<GameService>().AsSingle();
            Container.Bind<GameStateHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameLevelHandler>().AsSingle();
        }

        private void BindDoor()
        {
            Container.Bind<DoorRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<DoorSpawner>().AsSingle();

            Container.BindFactory<int, int, DoorColor, Vector2, DoorFacade, DoorFacade.DoorFactory>()
                     .FromPoolableMemoryPool<int, int, DoorColor, Vector2, DoorFacade, DoorFacade.DoorFacadePool>
                          (poolBinder => poolBinder
                                        .WithInitialSize(1)
                                        .FromSubContainerResolve()
                                        .ByNewPrefabInstaller<DoorInstaller>(doorPrefab)
                                        .UnderTransformGroup("Doors"));
        }

        private void BindSwitch()
        {
            Container.Bind<SwitchRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<SwitchSpawner>().AsSingle();

            Container.BindFactory<int, SwitchColor, Vector2, SwitchFacade, SwitchFacade.SwitchFactory>()
                     .FromPoolableMemoryPool<int, SwitchColor, Vector2, SwitchFacade, SwitchFacade.SwitchFacadePool>
                          (poolBinder => poolBinder
                                        .WithInitialSize(2)
                                        .FromSubContainerResolve()
                                        .ByNewPrefabInstaller<SwitchInstaller>(switchPrefab)
                                        .UnderTransformGroup("Switches"));
        }

        private void BindMap()
        {
            Container.Bind<MapRepository>().AsSingle();
        }

        private void BindPlayer()
        {
            Container.BindInterfacesAndSelfTo<PlayerService>().AsSingle();
            Container.Bind<PlayerView>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerAnimationHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerMoveHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerOutlookHandler>().AsSingle();
            Container.Bind<PlayerCollisionHandler>().AsSingle();
            Container.Bind<PlayerStateHandler>().AsSingle();
            Container.Bind<PlayerColorHandler>().AsSingle();
        }
    }
}