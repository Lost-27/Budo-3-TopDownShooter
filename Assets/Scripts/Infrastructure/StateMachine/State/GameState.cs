using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }

        public void Exit()
        {
        }

        #endregion

    }
}
