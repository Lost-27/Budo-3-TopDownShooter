using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerController : Unit
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


        public void AddLive()
        {
            if (_currentLives >= _maxLives)
                return;

            _currentLives++;
        }

        public void TakeDamage(int damage)
        {
            _currentLives -= damage;

            if (_currentLives < 1)
            {
                Death();
                // SceneHelper.Instance.LoadScene(3);
            }

            // OnLivesChanged?.Invoke();
        }

        private void Death()
        {
            if (_currentLives <= 0)
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
}