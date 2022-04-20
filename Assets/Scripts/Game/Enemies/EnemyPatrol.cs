using TDS.Game.Core;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyPatrol : EnemyIdleBehaviour
    {
        #region Variables

        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private PatrolPath _patrolPath;
        [SerializeField] private float _distanceToPoint = 1f;

        #endregion


        #region Constructor

        public void Construct(PatrolPath patrolPath)
        {
            _patrolPath = patrolPath;

            if (isActiveAndEnabled)
                SetTarget();
        }

        #endregion


        #region Unity lifecycle

        private void OnEnable()
        {
            if (_patrolPath == null)
                return;

            SetTarget();
        }

        private void Update()
        {
            if (_patrolPath == null)
                return;

            CheckPosition();
        }

        #endregion


        #region Private methods

        private void CheckPosition()
        {
            if (!_patrolPath.IsReachPosition(transform.position, _distanceToPoint))
                return;

            _patrolPath.SetNextPoint();
            SetTarget();
        }

        private void SetTarget()
        {
            _enemyMovement.SetTarget(_patrolPath.CurrentPoint());
            _enemyMovement.enabled = true;
        }

        #endregion
    }
}