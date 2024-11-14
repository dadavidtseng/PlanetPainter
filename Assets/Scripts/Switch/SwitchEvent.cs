namespace Switch
{
    public struct OnSwitchColorChanged
    {
        public readonly int         index;
        public readonly SwitchColor preColor;
        public readonly SwitchColor color;

        public OnSwitchColorChanged(int index, SwitchColor preColor, SwitchColor color)
        {
            this.index    = index;
            this.preColor = preColor;
            this.color    = color;
        }
    }
}