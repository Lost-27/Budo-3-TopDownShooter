using TDS.Infrastructure.StateMachine;

namespace TDS.Infrastructure
{
    public class Game
    {
        #region Variables

        public readonly IGameStateMachine GameStateMachine;

        #endregion
        

        #region Constructor

        public Game(IGameStateMachine gameStateMachine)
        {
            GameStateMachine = gameStateMachine;
        }

        #endregion
    }
}