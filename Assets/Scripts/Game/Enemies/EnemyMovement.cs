using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;

        // private Vector3 _startPos;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            // _startPos = transform.position;
        }

        // private void Update()
        // {
        //     MoveToTheTarget();
        // }

        #endregion


        #region Public methods

        public void ResetMove() =>
            _rb.velocity = Vector2.zero;

        public void MoveToTheTarget(Vector3 targetPos)
        {
            Vector3 direction = (targetPos - transform.position).normalized;
            _rb.velocity = direction * _speed;
        }

        // public void MoveToTheStartPoint()
        // {
        //     Vector2 direction = (_startPos - transform.position).normalized;
        //     _rb.velocity = direction * _speed;
        // }

        #endregion
    }
}