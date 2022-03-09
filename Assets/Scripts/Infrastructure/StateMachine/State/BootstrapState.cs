namespace TDS.Infrastructure.StateMachine.State
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            UnityEngine.Debug.Log("Enter BootstrapState");
            EnterMenuState();
        }

        public void Exit()
        {
            UnityEngine.Debug.Log("Exit BootstrapState");
        }

        private void EnterMenuState()
        {
            _gameStateMachine.Enter<MenuState>();
        }
    }
}