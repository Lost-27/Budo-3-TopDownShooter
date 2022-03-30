using TDS.Game.Input;
using TDS.Infrastructure.SceneHelper;

using TDS.Utility;
using TDS.Utility.Constants;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine.State
{
    public class BootstrapState : IState
    {
        #region Variables

        private readonly IGameStateMachine _gameStateMachine;
        private readonly Services.Services _services;

        #endregion


        #region Constructor

        public BootstrapState(IGameStateMachine gameStateMachine, Services.Services services, ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            _services = services;

            RegisterServices(coroutineRunner);
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
        
        private void RegisterServices(ICoroutineRunner coroutineRunner)
        {
            _services.Register<IGameStateMachine>(_gameStateMachine);

            _services.Register<IInputService>(new StandardInputService());
            _services.Register<ICoroutineRunner>(coroutineRunner);
            _services.Register<ISceneHelper>(new AsyncSceneHelper(_services.Get<ICoroutineRunner>()));
        }

        private void LoadMenuScene()
        {
            ISceneHelper sceneLoader = _services.Get<ISceneHelper>();  
            sceneLoader.Load(SceneTitles.MenuScene, EnterMenuState);
        }

        private void EnterMenuState()
        {
            _gameStateMachine.Enter<MenuState>();
        }

        #endregion
    }
}