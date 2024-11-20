using Data;
using Zenject;

namespace Game
{
    public class GameLevelHandler : IInitializable
    {
        [Inject] private readonly GameData    gameData;
        [Inject] private readonly DiContainer container;

        public void Initialize()
        {
            container.InstantiatePrefab(gameData.levelObjects);
        }
    }
}