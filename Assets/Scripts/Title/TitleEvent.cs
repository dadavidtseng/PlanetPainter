namespace Title
{
    public struct OnTitleStateChanged
    {
        public readonly TitleState preState;
        public readonly TitleState state;

        public OnTitleStateChanged(TitleState preState, TitleState state)
        {
            this.preState = preState;
            this.state    = state;
        }
    }
}