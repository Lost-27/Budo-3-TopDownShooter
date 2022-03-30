using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyAnimation _animation;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyPickupSpawner _enemyPickup;
        [SerializeField] private CircleCollider2D _collider;
        
        
        public void Death()
        {
            _animation.EnemyDeath();
            _enemyMovement.enabled = false;
            _enemyMovement.ResetMoveAndTarget();
            _enemyAttack.enabled = false;
            _collider.enabled = false;
            _enemyPickup.Spawn();
        }
    }
}
