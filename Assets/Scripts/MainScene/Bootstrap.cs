using Data;
using SceneTransition;
using UnityEngine;
using Zenject;

namespace MainScene
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private readonly ISceneService sceneService;
        [Inject] private readonly GameData      gameData;

        private void Start()
        {
            sceneService.LoadScene(1);
        }

        private void Update()
        {
            Debug.Log(gameData.difficulty);
        }
    }
}