using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyAnimation _enemyAnimation;

        [SerializeField] private float _attackDelay = 0.5f;
        [SerializeField] private int _damage = 1;

        [Header("Damage area settings")]
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _attackRadius;
        [SerializeField] private LayerMask _attackMask;

        private float _currentDelay;

        #endregion


        #region Unity lifecycle

        private void Update()
        {
            DecrementTimer(Time.deltaTime);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
        }

        #endregion


        #region Public methods

        public void Attack()
        {
            if (!CanAttack())
                return;

            _enemyAnimation.EnemyAttack();
            SetDelay();
        }

        public void AppleDamage()
        {
            Collider2D circle = Physics2D.OverlapCircle(_attackPoint.position, _attackRadius, _attackMask);

            if (circle == null)
                return;

            PlayerHealth playerHealth = circle.GetComponent<PlayerHealth>();

            if (playerHealth == null)
                return;

            playerHealth.TakeDamage(_damage);
        }

        #endregion


        #region Private methods

        private void DecrementTimer(float deltaTime) =>
            _currentDelay -= deltaTime;

        private bool CanAttack() =>
            _currentDelay <= 0f;

        private void SetDelay() =>
            _currentDelay = _attackDelay;

        #endregion
    }
}