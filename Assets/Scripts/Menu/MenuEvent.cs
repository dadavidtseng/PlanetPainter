namespace Menu
{
    public struct OnMenuStateChanged
    {
        public readonly MenuState preState;
        public readonly MenuState state;

        public OnMenuStateChanged(MenuState preState, MenuState state)
        {
            this.preState = preState;
            this.state    = state;
        }
    }
}