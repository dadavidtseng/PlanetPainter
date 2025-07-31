//----------------------------------------------------------------------------------------------------
// DoorRepository.cs
//----------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------

using System.Collections.Generic;

//----------------------------------------------------------------------------------------------------
namespace Door
{
    public class DoorRepository
    {
        private readonly Dictionary<int, DoorFacade> doorDictionary = new();

        public void AddDoor(int doorIndex, DoorFacade doorFacade)
        {
            doorDictionary.Add(doorIndex, doorFacade);
        }

        public void RemoveDoor(int doorIndex)
        {
            doorDictionary.Remove(doorIndex);
        }

        public DoorFacade GetDoorFacade(int doorIndex)
        {
            return doorDictionary[doorIndex];
        }

        public int GetDoorCount()
        {
            return doorDictionary.Count;
        }

        public bool IsAllDoorsOpen()
        {
            for (var i = 0; i < GetDoorCount(); i++)
            {
                var facade = GetDoorFacade(i);

                if (!facade.IsInteracted())
                    return false;
            }

            return true;
        }
    }
}