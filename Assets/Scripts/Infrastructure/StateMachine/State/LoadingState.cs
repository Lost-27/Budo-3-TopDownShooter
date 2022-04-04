using TDS.Game.Player;
using TDS.Game.UI;
using TDS.Infrastructure.SceneHelper;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine.State
{
    public class LoadingState : IPayloadState<string>
    {
        #region Variables

        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneHelper _sceneHelper;

        #endregion


        #region Constructor

        public LoadingState(IGameStateMachine stateMachine, ISceneHelper sceneHelper)
        {
            _stateMachine = stateMachine;
            _sceneHelper = sceneHelper;
        }

        #endregion


        #region Public methods

        public void Enter(string payload)
        {
            _sceneHelper.Load(payload, OnLoaded);
        }

        public void Exit()
        {
        }

        #endregion


        #region Private methods

        private void OnLoaded()
        {
            SetupHUD();

            _stateMachine.Enter<GameState>();
        }

        private static void SetupHUD()
        {
            PlayerHealth playerHealths = Object.FindObjectOfType<PlayerHealth>();
            GameObject hud = GameObject.Find("HUD");
            ActorUI actorUI = hud.GetComponentInChildren<ActorUI>();
            actorUI.Construct(playerHealths);
        }

        #endregion
    }
}