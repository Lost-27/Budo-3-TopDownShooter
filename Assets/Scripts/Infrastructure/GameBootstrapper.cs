using TDS.Infrastructure.StateMachine;
using TDS.Infrastructure.StateMachine.State;
using TDS.Utility;
using UnityEngine;

namespace TDS.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        #region Variables

        private Game _game;

        #endregion
        

        #region Unity lifecycle

        private void Awake()
        {
            _game = new Game(new GameStateMachine(Services.Services.Container, this));
            _game.GameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }

        #endregion
    }
}