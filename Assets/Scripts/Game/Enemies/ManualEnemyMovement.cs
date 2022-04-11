using UnityEngine;

namespace TDS.Game.Enemies
{
    public class ManualEnemyMovement : EnemyMovement
    {
        #region Variables

        [Header(nameof(ManualEnemyMovement))]
        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private Rigidbody2D _rb;

        private Transform _targetTransform;

        #endregion


        #region Unity lifecycle

        private void Update()
        {
            if (_targetTransform == null)
                return;

            Vector3 direction = Direction();
            MoveToTheTarget(direction);
            RotateTowardsTarget(direction);
        }

        #endregion


        #region Public methods

        public override void ResetMoveAndTarget()
        {
            _targetTransform = null;
            _rb.velocity = Vector2.zero;
            _enemyAnimation.EnemyMove(_rb.velocity.magnitude);
        }

        public override void SetTarget(Transform targetTransform) =>
            _targetTransform = targetTransform;

        #endregion


        #region Private methods

        private Vector3 Direction() =>
            (_targetTransform.position - transform.position).normalized;

        private void RotateTowardsTarget(Vector3 directionToTarget) =>
            transform.up = directionToTarget;

        private void MoveToTheTarget(Vector3 directionToTarget)
        {
            _rb.velocity = directionToTarget * _speed;
            _enemyAnimation.EnemyMove(_rb.velocity.magnitude);
        }

        #endregion
    }
}