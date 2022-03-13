using System.Collections;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _timeDelay = 3f;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;

        void Start()
        {
            StartCoroutine(AttackAfterWhile());
        }

        private IEnumerator AttackAfterWhile()
        {
            while (true)
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
    }
}