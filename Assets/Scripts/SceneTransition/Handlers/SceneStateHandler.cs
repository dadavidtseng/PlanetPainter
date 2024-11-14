namespace SceneTransition
{
    public class SceneStateHandler
    {
        private SceneState state = SceneState.Complete;

        public void ChangeState(SceneState state) => this.state = state;

        public SceneState GetSceneState() => state;
    }
}