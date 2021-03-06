using System;
using System.Collections.Generic;
using TDS.Infrastructure.SceneHelper;
using TDS.Infrastructure.StateMachine.State;
using TDS.Utility;

namespace TDS.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        #region Variables

        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        #endregion


        #region Constructor

        public GameStateMachine(Services.Services services, ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                {typeof(BootstrapState), new BootstrapState(this, services, coroutineRunner)},
                {typeof(MenuState), new MenuState(this)},
                {typeof(GameState), new GameState(this)},
                {typeof(LoadingState), new LoadingState(this, services.Get<ISceneHelper>())},
            };
        }

        #endregion


        #region Public methods

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        #endregion


        #region Private methods

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;

        #endregion
    }
}