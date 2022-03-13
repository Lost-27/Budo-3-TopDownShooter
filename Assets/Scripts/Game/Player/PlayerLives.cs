using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerLives : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private int _maxLives = 5;
        [SerializeField] private int _currentLives;

        #endregion
        

        #region Unity lifecycle

        private void Start()
        {
            _currentLives = _maxLives;
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
        
        //public void RemoveLive()
        //{
        //    CurrentLives--;

        //    if (CurrentLives < 1)
        //        SceneHelper.Instance.LoadScene(3);

        //    OnLivesChanged?.Invoke();
        //}

        public void AddLive()
        {
            if (_currentLives >= _maxLives)
                return;

            _currentLives++;

            // OnLivesChanged?.Invoke();
        }

        private void Death()
        {
            if (_currentLives <= 0)
            {
                _playerAnimation.PlayDeath();
            }
        }
    }
}
