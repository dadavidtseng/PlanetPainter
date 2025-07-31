//----------------------------------------------------------------------------------------------------
// DoorSpawner.cs
//----------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------

using Data;
using Zenject;

//----------------------------------------------------------------------------------------------------
namespace Door
{
    public class DoorSpawner : IInitializable
    {
        [Inject] private readonly GameData               gameData;
        [Inject] private readonly DoorFacade.DoorFactory factory;

        public void Initialize()
        {
            SpawnDoor();
        }

        private void SpawnDoor()
        {
            var doorCount = gameData.GetDoorCount();

            for (var i = 0; i < doorCount; i++)
            {
                factory.Create(gameData.GetDoorIndex(i),
                    gameData.GetDoorRegisteredSwitchIndex(i),
                    (DoorType)gameData.GetDoorTypeIndex(i),
                    (DoorColor)gameData.GetDoorColorIndex(i),
                    gameData.GetDoorSpawnPosition(i));
            }
        }
    }
}