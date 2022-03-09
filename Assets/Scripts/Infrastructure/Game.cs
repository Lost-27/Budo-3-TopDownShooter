using TDS.Infrastructure.StateMachine;

namespace TDS.Infrastructure
{
    public class Game
    {
        public readonly IGameStateMachine GameStateMachine;

        public Game(IGameStateMachine gameStateMachine)
        {
            GameStateMachine = gameStateMachine;
        }
    }
}