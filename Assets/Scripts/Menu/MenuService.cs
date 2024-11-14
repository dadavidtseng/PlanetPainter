using Zenject;

namespace Menu
{
    public class MenuService : IMenuService
    {
        [Inject] private readonly MenuStateHandler stateHandler;

        public void      ChangeMenuState(MenuState nextState) => stateHandler.ChangeState(nextState);
        public MenuState GetMenuState()                       => stateHandler.GetState();
    }
}