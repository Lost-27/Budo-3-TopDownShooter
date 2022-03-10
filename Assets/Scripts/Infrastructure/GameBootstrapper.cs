using TDS.Infrastructure.SceneHelper;
using TDS.Infrastructure.StateMachine;
using TDS.Infrastructure.StateMachine.State;
using TDS.Utility;
using UnityEngine;

namespace TDS.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(new GameStateMachine(new AsyncSceneHelper(this)));
            _game.GameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}