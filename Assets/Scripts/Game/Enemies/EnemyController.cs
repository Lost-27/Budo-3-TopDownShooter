using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyController : Unit
    {
        #region Variables

        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private LookAtTarget _lookAtTarget;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private CircleCollider2D _circleCollider2D;

        #endregion


        #region Unity lifecycle

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

        #region Private methods

        private void Death()
        {
            if (_currentLives <= 0)
            {
                _enemyAnimation.EnemyDeath();
                _lookAtTarget.enabled = false;
                _enemyAttack.enabled = false;
                _circleCollider2D.enabled = false;
            }
        }

        #endregion
    }
}