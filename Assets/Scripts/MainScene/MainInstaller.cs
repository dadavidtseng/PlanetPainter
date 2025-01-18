using Audio;
using Data;
using Misc;
using Notify;
using SceneTransition;
using UnityEngine;
using Zenject;

namespace MainScene
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private SceneScriptableObject    sceneScriptableObject;
        [SerializeField] private GameDataScriptableObject gameDataScriptableObject;
        [SerializeField] private ConsoleScriptableObject  consoleScriptableObject;

        public override void InstallBindings()
        {
            BindAudio();
            BindData();
            BindNotify();
            BindSceneTransition();
            BindMisc();
        }

        private void BindMisc()
        {
            Container.BindInstance(consoleScriptableObject).AsSingle().IfNotBound();
        }

        private void BindAudio()
        {
            Container.BindInterfacesAndSelfTo<AudioService>().AsSingle();
            Container.Bind<AudioView>().FromComponentInHierarchy().AsSingle();
        }

        private void BindData()
        {
            Container.BindInstance(gameDataScriptableObject.levelSettings).IfNotBound();
            Container.BindInstance(gameDataScriptableObject.playerSettings).IfNotBound();
            Container.BindInstance(gameDataScriptableObject.doorSettings).IfNotBound();
            Container.BindInstance(gameDataScriptableObject.switchSettings).IfNotBound();
            Container.Bind<GameData>().AsSingle();
        }

        private void BindNotify()
        {
            Container.BindInterfacesAndSelfTo<NotifyService>().AsSingle();
            Container.Bind<NotifyView>().FromComponentInHierarchy().AsSingle();
        }

        private void BindSceneTransition()
        {
            Container.BindInstance(sceneScriptableObject).IfNotBound();
            Container.BindInterfacesAndSelfTo<SceneService>().AsSingle();
            Container.Bind<SceneView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<SceneLoadHandler>().AsSingle();
            Container.Bind<SceneStateHandler>().AsSingle();
        }
    }
}