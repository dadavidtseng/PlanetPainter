namespace Title
{
    public interface ITitleService
    {
        void       ChangeTitleState(TitleState nextState);
        TitleState GetTitleState();
    }
}