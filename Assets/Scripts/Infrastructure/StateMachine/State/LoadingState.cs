using TDS.Infrastructure.SceneHelper;

namespace TDS.Infrastructure.StateMachine.State
{
    public class LoadingState : IPayloadState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneHelper _sceneHelper;

        public LoadingState(IGameStateMachine stateMachine, ISceneHelper sceneHelper)
        {
            _stateMachine = stateMachine;
            _sceneHelper = sceneHelper;
        }

        public void Enter(string payload)
        {
            _sceneHelper.Load(payload, OnLoaded);
        }

        private void OnLoaded()
        {
            // TODO: Some actions

            _stateMachine.Enter<GameState>();
        }

        public void Exit()
        {
        }
    }
}