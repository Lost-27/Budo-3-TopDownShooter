using System;
using System.Collections;
using TDS.Game.Enemies;
using TDS.Game.Player;
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

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _velocity = Vector3.up * _speed;

            StartCoroutine(DeleteBulletByLifeTime());
        }

        private void Update() =>
            Move();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            
            if (player != null)
                player.TakeDamage(_damage);

            else if (enemy != null)
                enemy.TakeDamage(_damage);
            
            Delete();
        }

        #endregion


        #region Private methods

        private void Move() =>
            transform.Translate(_velocity * Time.deltaTime);

        private IEnumerator DeleteBulletByLifeTime()
        {
            yield return new WaitForSeconds(_lifeTime);

            Delete();
        }

        private void Delete() =>
            Destroy(gameObject);

        #endregion
    }
}