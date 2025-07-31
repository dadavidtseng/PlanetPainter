//----------------------------------------------------------------------------------------------------
// GameEvent.cs
//----------------------------------------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------

namespace Game
{
    public struct OnGameStateChanged
    {
        public readonly GameState preState;
        public readonly GameState state;

        //----------------------------------------------------------------------------------------------------
        public OnGameStateChanged(GameState preState,
                                  GameState state)
        {
            this.preState = preState;
            this.state    = state;
        }
    }
}