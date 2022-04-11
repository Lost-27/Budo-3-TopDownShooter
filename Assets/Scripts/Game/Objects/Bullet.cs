using System.Collections;
using Lean.Pool;
using TDS.Game.Enemies;
using TDS.Utility.Constants;
using UnityEngine;

namespace TDS.Game.Objects
{
    public class Bullet : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _damage = 1;
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        private Vector3 _velocity;
        private IEnumerator _despawnBulletRoutine;

        #endregion


        #region Unity lifecycle

        private void OnEnable()
        {
            _despawnBulletRoutine = DespawnBulletByLifeTime();
            StartCoroutine(_despawnBulletRoutine);
        }

        private void OnDisable()
        {
            if (_despawnBulletRoutine != null)
                StopCoroutine(_despawnBulletRoutine);
        }

        private void Start()
        {
            _velocity = Vector3.up * _speed;
        }

        private void Update() =>
            Move();

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.Enemy))
            {
                col.GetComponent<EnemyHealth>().TakeDamage(_damage);
            }

            DespawnBullet();
        }

        #endregion


        #region Private methods

        private void Move() =>
            transform.Translate(_velocity * Time.deltaTime);

        private IEnumerator DespawnBulletByLifeTime()
        {
            yield return new WaitForSeconds(_lifeTime);

            DespawnBullet();
        }

        private void DespawnBullet() =>
            LeanPool.Despawn(gameObject);

        #endregion
    }
}