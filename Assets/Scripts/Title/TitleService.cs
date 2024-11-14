using Zenject;

namespace Title
{
    public class TitleService : ITitleService
    {
        [Inject] private readonly TitleStateHandler stateHandler; 
        
        public void       ChangeTitleState(TitleState nextState) => stateHandler.ChangeState(nextState);
        public TitleState GetTitleState()                        => stateHandler.GetState();
    }
}