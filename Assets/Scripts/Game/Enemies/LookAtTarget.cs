using UnityEngine;

namespace TDS.Game.Enemies
{
    public class LookAtTarget : MonoBehaviour
    {
        #region Variables

        // [SerializeField] private Enemy _enemy;
        // [SerializeField] private Transform _playerTransform; // TODO: Inject

        // private Transform _startPoint;

        #endregion


        #region Unity lifecycle

        // private void Start()
        // {
        //     _startPoint.position = transform.position;
        // }

        // private void Update()
        // {
        //     if (_playerTransform != null)
        //     {
        //         RotateTowardsTarget();
        //     }
        // }

        #endregion


        #region Public methods

        public void RotateTowardsTarget(Vector3 targetPos)
        {
            Vector3 directionToTarget = Direction(targetPos);
            transform.up = directionToTarget;
        }

        // public void RotateTowardsTarget2()
        // {
        //     Vector2 directionToTarget = Direction2();
        //     transform.up = directionToTarget;
        // }

        #endregion


        #region Private methods

        private Vector3 Direction(Vector3 targetPos) =>
            targetPos - transform.position;

        // private Vector2 Direction2() =>
        //     _startPoint.position - transform.position;

        #endregion
    }
}