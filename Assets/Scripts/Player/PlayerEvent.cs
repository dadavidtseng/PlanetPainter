namespace Player
{
    public struct OnPlayerStateChanged
    {
        public readonly PlayerState preState;
        public readonly PlayerState state;

        public OnPlayerStateChanged(PlayerState preState, PlayerState state)
        {
            this.preState = preState;
            this.state    = state;
        }
    }

    public struct OnPlayerColorChanged
    {
        public readonly PlayerColor preColor;
        public readonly PlayerColor color;

        public OnPlayerColorChanged(PlayerColor preColor, PlayerColor color)
        {
            this.preColor = preColor;
            this.color    = color;
        }
    }
}