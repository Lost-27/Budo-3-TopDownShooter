using TDS.Infrastructure.SceneHelper;
using TDS.UI;
using TDS.Utility.Constants;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine.State
{
    public class MenuState : IState
    {
        #region Variables

        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneHelper _sceneHelper;

        #endregion
        

        #region Constructor

        public MenuState(IGameStateMachine gameStateMachine, ISceneHelper sceneHelper)
        {
            _gameStateMachine = gameStateMachine;
            _sceneHelper = sceneHelper;
        }

        #endregion


        #region Public methods

        public void Enter()
        {
            Debug.Log($"Enter MenuState Frame <{Time.frameCount}>");

            MenuScreen.OnPlayButtonClicked += PlayButtonClicked;
        }

        public void Exit()
        {
            Debug.Log($"Exit MenuState Frame <{Time.frameCount}>");

            MenuScreen.OnPlayButtonClicked -= PlayButtonClicked;
        }

        #endregion


        #region Private methods

        private void PlayButtonClicked() =>
            _sceneHelper.Load(SceneTitles.GameScene, EnterGameState);

        private void EnterGameState() =>
            _gameStateMachine.Enter<GameState>();

        #endregion
    }
}