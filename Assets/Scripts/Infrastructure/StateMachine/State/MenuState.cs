using TDS.Infrastructure.SceneHelper;
using TDS.UI;
using TDS.Utility.Constants;

namespace TDS.Infrastructure.StateMachine.State
{
    public class MenuState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneHelper _sceneHelper;

        public MenuState(IGameStateMachine gameStateMachine, ISceneHelper sceneHelper)
        {
            _gameStateMachine = gameStateMachine;
            _sceneHelper = sceneHelper;
        }

        public void Enter()
        {
            UnityEngine.Debug.Log($"Enter MenuState Frame <{UnityEngine.Time.frameCount}>");

            MenuScreen.OnPlayButtonClicked += PlayButtonClicked;
        }

        public void Exit()
        {
            UnityEngine.Debug.Log($"Exit MenuState Frame <{UnityEngine.Time.frameCount}>");

            MenuScreen.OnPlayButtonClicked -= PlayButtonClicked;
        }

        private void PlayButtonClicked() =>
            _sceneHelper.Load(SceneTitles.GameScene, EnterGameState);

        private void EnterGameState() =>
            _gameStateMachine.Enter<GameState>();
    }
}