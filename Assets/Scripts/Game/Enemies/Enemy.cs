using System.Collections.Generic;
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
            // BackToStartPosition = 5,
            Patrol = 6,
        }

        #endregion


        #region Variables

        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyPatrol _enemyPatrol;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private CircleCollider2D _circleCollider;

        [Header("Settings")]
        [SerializeField] private float _moveRadius = 1f;
        [SerializeField] private float _attackRadius = 0.5f;

        [Header("Pickup settings")]
        [SerializeField] private List<GameObject> _pickupPrefab;

        [Range(0f, 100f)]
        [SerializeField] private float _pickupChance;

        [SerializeField] private bool _isPatrol;

        private Transform _playerTransform;
        // private Transform _startPoint;

        [SerializeField] private State _currentState = State.None;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _currentState = State.None;
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
            // _startPoint.position = transform.position;
            
            _enemyPatrol.enabled = false;
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
                SetState(State.Move);
            }
            else
            {

                if (_isPatrol)
                {
                    SetState(State.Patrol);
                }
                else
                {
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
                    _enemyPatrol.enabled = false;
                    _enemyMovement.ResetMove();
                    _enemyAnimation.EnemyIdle(_rb.velocity.magnitude);
                    break;
                case State.Move:
                    _enemyPatrol.enabled = false;
                    _enemyMovement.SetTarget(_playerTransform);
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
                    _enemyAttack.enabled = false;
                    _circleCollider.enabled = false;
                    CreatePickupIfNeeded();
                    break;
                // case State.BackToStartPosition:
                //     _enemyMovement.SetTarget(_startPoint);
                //     break;
                case State.Patrol:
                    _enemyPatrol.enabled = true;
                    break;
            }
        }

        private void UpdateState(State state)
        {
            switch (state)
            {
                case State.Move:
                    _enemyAnimation.EnemyMove(_rb.velocity.magnitude);
                    // _lookAtTarget.RotateTowardsTarget(_playerTransform.position);
                    // _enemyMovement.MoveToTheTarget();
                    // _enemyMovement.MoveToTheTarget(_playerTransform.position);
                    break;
                case State.Attack:
                    _enemyAttack.Attack();
                    break;
                    // case State.BackToStartPosition:
                    //     _lookAtTarget.RotateTowardsTarget(_startPoint.position);
                    //     // _enemyMovement.MoveToTheTarget();
                    //     // _enemyMovement.MoveToTheTarget(_startPoint);
                    //     break;
            }
        }

        // private bool IsNearStartPosition()
        // {
        //     return Vector3.Distance(transform.position, _startPoint.position) >= 0.2f;
        // }

        private void CreatePickupIfNeeded()
        {
            float randomChance = Random.Range(1f, 100f);

            if (_pickupChance > randomChance)
            {
                Instantiate(_pickupPrefab[0], transform.position, Quaternion.identity);
            }
        }

        #endregion
    }
}