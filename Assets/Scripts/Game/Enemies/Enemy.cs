using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class Enemy : MonoBehaviour
    {
        #region Local data

        private enum State
        {
            None = 0,
            Idle = 1,
            Move = 2,
            Attack = 3,
            Death = 4,
        }

        #endregion


        #region Variables

        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private LookAtTarget _lookAtTarget;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private CircleCollider2D _circleCollider;

        [Header("Settings")] 
        [SerializeField] private float _moveRadius = 1f;
        [SerializeField] private float _attackRadius = 0.5f;

        private Transform _playerTransform;
        private Vector3 _startPoint;

        [SerializeField] private State _currentState = State.None;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
            _startPoint = transform.position;
        }

        private void Update()
        {
            if (_currentState == State.Death)
                return;

            float distance = Vector3.Distance(_playerTransform.position, transform.position);

            if (distance <= _attackRadius)
            {
                SetState(State.Attack);
            }
            else if (distance <= _moveRadius)
            {
                _lookAtTarget.RotateTowardsTarget(_playerTransform.position);
                _enemyMovement.MoveToTheTarget(_playerTransform.position);
                SetState(State.Move);
            }
            else
            {
                _lookAtTarget.RotateTowardsTarget(_startPoint);
                _enemyMovement.MoveToTheTarget(_startPoint);

                if (transform.position == _startPoint)
                {
                    _enemyMovement.ResetMove();
                    SetState(State.Idle);
                }
                    
            }

            UpdateState(_currentState);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _moveRadius);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRadius);
        }

        #endregion


        #region Public methods

        public void Death()
        {
            SetState(State.Death);
        }

        #endregion


        #region Private methods

        private void SetState(State state)
        {
            if (_currentState == state)
                return;

            _currentState = state;

            switch (_currentState)
            {
                case State.Idle:
                    _enemyMovement.enabled = false;
                    _enemyMovement.ResetMove();
                    break;
                case State.Move:
                    _enemyMovement.enabled = true;
                    break;
                case State.Attack:
                    _enemyMovement.enabled = false;
                    _enemyMovement.ResetMove();
                    _enemyAnimation.EnemyMove(_rb.velocity.magnitude);
                    break;
                case State.Death:
                    _enemyAnimation.EnemyDeath();
                    _enemyMovement.enabled = false;
                    _enemyMovement.ResetMove();
                    _lookAtTarget.enabled = false;
                    _enemyAttack.enabled = false;
                    _circleCollider.enabled = false;
                    break;
            }
        }

        private void UpdateState(State state)
        {
            switch (state)
            {
                case State.Move:
                    _enemyAnimation.EnemyMove(_rb.velocity.magnitude);
                    break;
                case State.Attack:
                    _enemyAttack.Attack();
                    break;
            }
        }

        #endregion
    }
}