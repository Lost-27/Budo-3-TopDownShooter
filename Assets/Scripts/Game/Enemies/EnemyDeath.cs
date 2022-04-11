using System;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyPickupSpawner _enemyPickup;
        [SerializeField] private GameObject _agroRange;
        [SerializeField] private GameObject _attackRange;
        [SerializeField] private GameObject _sliderHP;
        [SerializeField] private CircleCollider2D _collider;        

        #endregion


        #region Events

        public event Action OnEnemyDeath;

        #endregion


        #region Properties

        public bool IsEnemyDeath { get; private set; }

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            IsEnemyDeath = false;
        }

        #endregion


        #region Public methods

        public void Death()
        {
            IsEnemyDeath = true;
            _animation.EnemyDeath();
            
            _enemyAttack.enabled = false;
            _collider.enabled = false;
            _agroRange.SetActive(false);
            _attackRange.SetActive(false);
            _sliderHP.SetActive(false);

            _enemyMovement.enabled = false;
            _enemyMovement.ResetMoveAndTarget();

            _enemyPickup.Spawn();

            OnEnemyDeath?.Invoke();
        }

        #endregion
    }
}