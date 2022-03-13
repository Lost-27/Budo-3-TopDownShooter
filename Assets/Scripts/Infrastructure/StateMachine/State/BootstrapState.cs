using TDS.Infrastructure.SceneHelper;
using TDS.Utility.Constants;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine.State
{
    public class BootstrapState : IState
    {
        #region Variables

        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneHelper _sceneHelper;   

        #endregion

        
        #region Constructor

        public BootstrapState(IGameStateMachine gameStateMachine, ISceneHelper sceneHelper)
        {
            _gameStateMachine = gameStateMachine;
            _sceneHelper = sceneHelper;
        }

        #endregion
        

        #region Public methods

        public void Enter()
        {
            Debug.Log($"Enter BootstrapState Frame <{Time.frameCount}>");
            LoadMenuScene();            
        }

        public void Exit()
        {
            Debug.Log($"Exit BootstrapState Frame <{Time.frameCount}>");
        }

        #endregion
        

        #region Private methods

        private void LoadMenuScene()
        {
            _sceneHelper.Load(SceneTitles.MenuScene, EnterMenuState);
        }

        private void EnterMenuState()
        {
            _gameStateMachine.Enter<MenuState>();
        }

        #endregion
    }
}