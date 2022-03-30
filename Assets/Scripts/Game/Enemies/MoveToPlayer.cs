using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class MoveToPlayer : EnemyFollow
    {
        [SerializeField] private EnemyMovement _enemyMovement;

        private Transform _playerTransform;

        private void OnEnable()
        {
            _enemyMovement.SetTarget(_playerTransform);
            _enemyMovement.enabled = true;            
        }
        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
            _enemyMovement.enabled = false;              //?
            enabled = false;

        }
        private void OnDisable()
        {
            _enemyMovement.enabled = false;
            _enemyMovement.ResetMoveAndTarget();
        }
    }
}
