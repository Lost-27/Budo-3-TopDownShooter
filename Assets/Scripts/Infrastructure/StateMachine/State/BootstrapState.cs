using TDS.Infrastructure.SceneHelper;
using TDS.Utility.Constants;

namespace TDS.Infrastructure.StateMachine.State
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneHelper _sceneHelper;        

        public BootstrapState(IGameStateMachine gameStateMachine, ISceneHelper sceneHelper)
        {
            _gameStateMachine = gameStateMachine;
            _sceneHelper = sceneHelper;
        }

        public void Enter()
        {
            UnityEngine.Debug.Log($"Enter BootstrapState Frame <{UnityEngine.Time.frameCount}>");
            LoadMenuScene();            
        }

        public void Exit()
        {
            UnityEngine.Debug.Log($"Exit BootstrapState Frame <{UnityEngine.Time.frameCount}>");
        }

        private void LoadMenuScene()
        {
            _sceneHelper.Load(SceneTitles.MenuScene, EnterMenuState);
        }

        private void EnterMenuState()
        {
            _gameStateMachine.Enter<MenuState>();
        }
    }
}