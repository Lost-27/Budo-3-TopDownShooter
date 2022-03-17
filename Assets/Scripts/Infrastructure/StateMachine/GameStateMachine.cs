using System;
using System.Collections.Generic;
using TDS.Game.Input;
using TDS.Infrastructure.SceneHelper;
using TDS.Infrastructure.StateMachine.State;
using TDS.Utility;

namespace TDS.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        #region Variables

        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        #endregion


        #region Constructor

        public GameStateMachine(Services.Services services, ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, IState>
            {
                {typeof(BootstrapState), new BootstrapState(this, services, coroutineRunner)},
                {typeof(MenuState), new MenuState(this, services.Get<ISceneHelper>())},
                {typeof(GameState), new GameState(this)},
            };
        }

        #endregion


        #region Public methods

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }

        // public void Exit<TState>() where TState : IState
        // {     
        // }

        #endregion
    }
}