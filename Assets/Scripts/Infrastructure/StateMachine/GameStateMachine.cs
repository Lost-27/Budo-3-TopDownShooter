using System;
using System.Collections.Generic;
using TDS.Infrastructure.StateMachine.State;

namespace TDS.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>
            {
                {typeof(BootstrapState), new BootstrapState(this)},
                {typeof(MenuState), new MenuState(this)}
            };
        }
        
        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }

        // public void Exit<TState>() where TState : IState
        // {     
        // }
    }
}