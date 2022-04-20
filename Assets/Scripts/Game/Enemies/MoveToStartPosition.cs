using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class MoveToStartPosition : EnemyIdleBehaviour
    {
        #region Variables

        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private MoveToPlayer _moveToPlayer;

        private Transform _startPoint;
        private PlayerDeath _playerDeath;

        #endregion


        #region Unity lifecycle       

        private void Start()
        {
            // _playerDeath = FindObjectOfType<PlayerDeath>();
            _playerDeath = FindObjectOfType<PlayerDeath>();
            _playerDeath.OnDeath += PlayerDeath;

            _startPoint = new GameObject($"StartPointOf{name}").transform;
            _startPoint.position = transform.position;
        }

        private void OnDestroy()
        {
            _playerDeath.OnDeath -= PlayerDeath;
        }

        #endregion


        #region Private methods

        private void PlayerDeath()
        {
            _playerDeath.OnDeath -= PlayerDeath;

            _moveToPlayer.enabled = false;
            _enemyMovement.SetTarget(_startPoint);
            _enemyMovement.enabled = true;
        }

        #endregion
    }
}