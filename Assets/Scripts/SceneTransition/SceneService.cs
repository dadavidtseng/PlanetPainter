using Zenject;

namespace SceneTransition
{
    public class SceneService : ISceneService
    {
        [Inject] private readonly SceneLoadHandler loadHandler;

        public void LoadScene(int sceneIndex, bool IsFadeOut = true) => loadHandler.LoadScene(sceneIndex, IsFadeOut);
        public void FadeOut()              => loadHandler.FadeOut();
    }
}