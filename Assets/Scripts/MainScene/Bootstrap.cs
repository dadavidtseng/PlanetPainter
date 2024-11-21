using Data;
using SceneTransition;
using UnityEngine;
using Zenject;

namespace MainScene
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private readonly ISceneService sceneService;

        private void Start()
        {
            sceneService.LoadScene(0);
        }
    }
}