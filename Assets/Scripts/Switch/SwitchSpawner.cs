using Data;
using UnityEngine;
using Zenject;

namespace Switch
{
    public class SwitchSpawner : IInitializable
    {
        [Inject] private readonly GameData                   gameData;
        [Inject] private readonly SwitchFacade.SwitchFactory factory;

        public void Initialize()
        {
            SpawnSwitch();
        }

        private void SpawnSwitch()
        {
            var switchCount = gameData.GetSwitchCount();

            for (var i = 0; i < switchCount; i++)
            {
                factory.Create(gameData.GetSwitchIndex(i),
                               (SwitchColor)gameData.GetSwitchColorIndex(i),
                               gameData.GetSwitchSpawnPosition(i));
            }
        }
    }
}