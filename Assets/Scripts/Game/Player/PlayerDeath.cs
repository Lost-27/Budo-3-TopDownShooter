using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private CircleCollider2D _collider;

        #endregion


        #region Events

        public event Action OnDeath;

        #endregion


        #region Properties

        public bool IsPlayerDeath { get; private set; }

        #endregion


        #region Unity lifecycle

        private void OnEnable()
        {
            _playerHealth.OnChanged += HealthChanged;
        }
        private void OnDisable()
        {
            _playerHealth.OnChanged -= HealthChanged;
        }

        private void Start()
        {
            IsPlayerDeath = false;
        }

        #endregion


        #region Private methods

        private void HealthChanged()
        {
            if (!IsPlayerDeath && _playerHealth.CurrentHp < 1)
                Death();
        }

        private void Death()
        {
            IsPlayerDeath = true;
            _animation.PlayDeath();
            _playerMovement.enabled = false;
            _playerMovement.ResetMove();
            _playerAttack.enabled = false;
            _collider.enabled = false;

            OnDeath?.Invoke();
        }

        #endregion
    }
}