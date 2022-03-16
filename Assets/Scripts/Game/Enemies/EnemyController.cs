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
        

        #region Public methods
        
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

        #endregion

        #region Private methods

        private void Death()
        {
            if (_currentLives <= 0)
            {
                _enemyAnimation.EnemyDeath();
                _lookAtTarget.enabled = false;
                _enemyAttack.enabled = false;
                _enemyAttack.StopAttack();
                _circleCollider2D.enabled = false;
            }
        }

        #endregion
    }
}