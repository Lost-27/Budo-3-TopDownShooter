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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
            {
                --_currentLives;
                Destroy(collision.gameObject);
                Death();
            }
        }

        #endregion


        public void AddLive()
        {
            if (_currentLives >= _maxLives)
                return;

            _currentLives++;
        }

        private void Death()
        {
            if (_currentLives <= 0)
            {
                IsPlayerDeath = true;
                _playerAnimation.PlayDeath();
                _playerMovement.enabled = false;
                _playerAttack.enabled = false;
                _circleCollider2D.enabled = false;
            }
        }
    }
}