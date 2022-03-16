using System.Collections;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerController playerController; // TODO: Inject
        [SerializeField] private float _timeDelay = 3f;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;

        private IEnumerator _attackRoutine;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _attackRoutine = AttackAfterWhile();
            StartCoroutine(_attackRoutine);
        }

        #endregion

        #region Public methods

        public void StopAttack()
        {
            if (_attackRoutine != null)
                StopCoroutine(_attackRoutine);
        }

        #endregion


        #region Private methods

        private IEnumerator AttackAfterWhile()
        {
            while (!playerController.IsPlayerDeath)
            {
                yield return new WaitForSeconds(_timeDelay);

                Attack();
            }
        }

        private void Attack()
        {
            CreateBullet();
        }

        private void CreateBullet() =>
            Instantiate(_bulletPrefab, _bulletSpawnPointTransform.position, _bulletSpawnPointTransform.rotation);

        #endregion
    }
}