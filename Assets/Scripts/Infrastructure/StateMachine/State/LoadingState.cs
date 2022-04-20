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
            GameObject hud = GameObject.Find("HUD");
            PlayerHealth playerHealth = Object.FindObjectOfType<PlayerHealth>();
            SetupHpUI(hud, playerHealth);
            SetupAmmoUI(hud, playerHealth);
        }

        private static void SetupAmmoUI(GameObject hud, PlayerHealth playerHealth)
        {
            AmmoUI ammoUI = hud.GetComponentInChildren<AmmoUI>();
            PlayerAttack playerAttack = playerHealth.GetComponent<PlayerAttack>();
            ammoUI.Construct(playerAttack);
        }

        private static void SetupHpUI(GameObject hud, PlayerHealth playerHealth)
        {            
            ActorUI actorUI = hud.GetComponentInChildren<ActorUI>();
            actorUI.Construct(playerHealth);
        }

        #endregion
    }
}