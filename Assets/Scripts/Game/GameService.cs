using Zenject;

namespace Game
{
    public class GameService: IGameService
    {
        [Inject] private readonly GameStateHandler stateHandler;
        
        public void      ChangeState(GameState nextState) => stateHandler.ChangeState(nextState);
        public GameState GetGameState()                   => stateHandler.GetGameState();
    }
}