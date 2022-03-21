using UnityEngine;

namespace TDS.Game.Player
{
    public class Player : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private CircleCollider2D _circleCollider2D;

        #endregion


        #region Properties

        public bool IsPlayerDeath { get; private set; }

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            IsPlayerDeath = false;
        }

        #endregion
        

        public void Death()
        {
            IsPlayerDeath = true;
            _playerAnimation.PlayDeath();
            _playerMovement.enabled = false;
            _playerMovement.ResetMove();
            _playerAttack.enabled = false;
            _circleCollider2D.enabled = false;
        }
    }
}