using TDS.UI;
using TDS.Utility.Constants;

namespace TDS.Infrastructure.StateMachine.State
{
    public class GameState : IState
    {
        #region Variables

        private readonly GameStateMachine _gameStateMachine;

        #endregion


        #region Constructor

        public GameState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        #endregion


        #region Public methods

        public void Enter()
        {
            DeathScreen.OnRestartButtonClicked += RestartButtonClicked;
        }

        public void Exit()
        {
            DeathScreen.OnRestartButtonClicked -= RestartButtonClicked;
        }

        #endregion

        #region Private methods

        private void RestartButtonClicked() =>
            _gameStateMachine.Enter<LoadingState, string>(SceneTitles.GameScene); //? SceneManager.LoadScene(SceneManager.GetActiveScene);

        #endregion
    }
}