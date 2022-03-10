using System.Collections;
using UnityEngine;

namespace TDS.Game.Objects
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        private Vector3 _velocity;

        private void Start()
        {
            _velocity = Vector3.up * _speed;

            StartCoroutine(DeleteBulletByLifeTime());
        }

        private void Update() =>
            Move();

        private void Move() =>
            transform.Translate(_velocity * Time.deltaTime);

        private IEnumerator DeleteBulletByLifeTime()
        {
            yield return new WaitForSeconds(_lifeTime);

            Delete();
        }

        private void Delete() =>
            Destroy(gameObject);
    }
}