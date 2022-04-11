using UnityEngine;

namespace TDS.Game.Enemies
{
    public abstract class EnemyMovement : MonoBehaviour
    {
        #region Variables

        [Header(nameof(EnemyMovement))]
        // [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] protected float _speed;

        #endregion


        #region Public methods

        public abstract void ResetMoveAndTarget();
        public abstract void SetTarget(Transform targetTransform);

        #endregion
    }
}