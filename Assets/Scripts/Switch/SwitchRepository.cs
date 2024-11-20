using System.Collections.Generic;

namespace Switch
{
    public class SwitchRepository
    {
        private readonly Dictionary<int, SwitchFacade> switchDictionary = new();

        public void AddSwitch(int switchIndex, SwitchFacade switchFacade)
        {
            switchDictionary.Add(switchIndex, switchFacade);
        }

        public void RemoveSwitch(int doorIndex)
        {
            switchDictionary.Remove(doorIndex);
        }

        public SwitchFacade GetSwitchFacade(int switchIndex)
        {
            return switchDictionary[switchIndex];
        }

        public int GetSwitchCount()
        {
            return switchDictionary.Count;
        }
    }
}