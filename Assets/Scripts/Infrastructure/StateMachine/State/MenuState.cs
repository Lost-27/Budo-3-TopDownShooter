using TDS.UI;
using TDS.Utility.Constants;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine.State
{
    public class MenuState : IState
    {
        #region Variables

        private readonly IGameStateMachine _gameStateMachine;        

        #endregion
        

        #region Constructor

        public MenuState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;            
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
            _gameStateMachine.Enter<LoadingState, string>(SceneTitles.GameScene);
        

        #endregion
    }
}