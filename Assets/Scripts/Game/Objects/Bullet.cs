using System.Collections;
using UnityEngine;

namespace TDS.Game.Objects
{
    public class Bullet : MonoBehaviour
    {
        #region Variables

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