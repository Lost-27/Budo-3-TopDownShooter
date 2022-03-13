using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyLives : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private int _maxLives = 1;
        [SerializeField] private int _currentLives;

        #endregion
        

        #region Unity lifecycle

        private void Start()
        {
            _currentLives = _maxLives;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
            {
                --_currentLives;
                Destroy(collision.gameObject);
                Death();
            }
        }

        #endregion

        private void Death()
        {
            if (_currentLives <= 0)
            {
                _enemyAnimation.EnemyDeath();
            }
        }
    }
}
