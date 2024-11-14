using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Zenject;

namespace SceneTransition
{
    public class SceneLoadHandler
    {
        [Inject] private readonly SceneScriptableObject sceneScriptableObject;
        [Inject] private readonly SceneStateHandler     stateHandler;
        [Inject] private readonly SceneView             view;

        private readonly Queue<AsyncOperationHandle<SceneInstance>> loadedScenes = new();

        private int sceneIndex;

        public async void LoadScene(int sceneIndex, bool IsFadeOut = true)
        {
            if (!await PreLoadScene())
                return;

            this.sceneIndex = sceneIndex;

            stateHandler.ChangeState(SceneState.Unloading);

            if (loadedScenes.Count > 0)
            {
                var total = loadedScenes.Count;

                for (var i = 0; i < total; i++)
                {
                    var unloadScene = loadedScenes.Dequeue();

                    await Addressables.UnloadSceneAsync(unloadScene).Task;
                }
            }

            stateHandler.ChangeState(SceneState.Loading);
            var loadedScene =
                Addressables.LoadSceneAsync(sceneScriptableObject.sceneAssets[sceneIndex], LoadSceneMode.Additive);

            // 這裡可以使用進度條
            while (!loadedScene.IsDone)
            {
                view.GetProgressBarSlider().value = loadedScene.PercentComplete; // 更新進度條的值

                await UniTask.Yield(); // 等待幀數再進行下一次更新
            }

            loadedScenes.Enqueue(loadedScene);

            stateHandler.ChangeState(SceneState.Complete);

            if (IsFadeOut)
                view.SetAppear(false);
        }

        private async UniTask<bool> PreLoadScene()
        {
            if (stateHandler.GetSceneState() != SceneState.Complete)
                return false;

            // 開始讀取場景
            view.SetAppear(true);

            if (GetCurrentSceneIndex() != 0)
                view.GetProgressBarSlider().gameObject.SetActive(true); // 顯示進度條

            stateHandler.ChangeState(SceneState.Loading);

            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));

            return true;
        }

        public void FadeOut()
        {
            if (stateHandler.GetSceneState() != SceneState.Complete)
                return;

            view.SetAppear(false);
            view.GetProgressBarSlider().gameObject.SetActive(false); // 隱藏進度條
        }

        public int GetCurrentSceneIndex() => sceneIndex;
    }
}