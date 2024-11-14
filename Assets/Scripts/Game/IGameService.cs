namespace Game
{
    public interface IGameService
    {
        void      ChangeState(GameState nextState);
        GameState GetGameState();
    }
}