namespace Menu
{
    public interface IMenuService
    {
        void      ChangeMenuState(MenuState nextState);
        MenuState GetMenuState();
    }
}