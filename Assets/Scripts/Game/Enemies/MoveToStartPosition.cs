using TDS.Game.Enemies;
using TDS.Game.Player;
using UnityEngine;

namespace TDS
{
    public class MoveToStartPosition : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private MoveToPlayer _moveToPlayer;

        private Transform _startPoint;
        private PlayerDeath _playerDeath;

        #endregion


        #region Unity lifecycle

        private void OnEnable()
        {
            _playerDeath = FindObjectOfType<PlayerDeath>();
            _playerDeath.OnPlayerDeath += PlayerDeath;
        }

        private void Start()
        {
            // _playerDeath = FindObjectOfType<PlayerDeath>();

            _startPoint = new GameObject($"StartPointOf{name}").transform;
            _startPoint.position = transform.position;
            
        }

        private void OnDisable()
        {
            _playerDeath.OnPlayerDeath -= PlayerDeath; //?
        }

        #endregion


        #region Private methods

        private void PlayerDeath()
        {
            _moveToPlayer.enabled = false;
            _enemyMovement.SetTarget(_startPoint);
            _enemyMovement.enabled = true;
            _playerDeath.OnPlayerDeath -= PlayerDeath;
            
            //_playerDeath.OnPlayerDeath -= PlayerDeath;
        }

        #endregion
    }
}