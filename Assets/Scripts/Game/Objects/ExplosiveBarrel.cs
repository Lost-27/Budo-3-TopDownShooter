using System.Collections;
using TDS.Game.Core;
using TDS.Utility.Constants;
using UnityEngine;

namespace TDS.Game.Objects
{
    public class ExplosiveBarrel : MonoBehaviour, IDamageable
    {
        #region Variables

        [SerializeField] private Collider2D _collider2D;

        [Header("Explosion setting")] 
        [SerializeField] private float _damageRadius;
        [SerializeField] private int _damage = 2;
        [SerializeField] private LayerMask _layerMask;

        [Header("Animation")]
        [SerializeField] private Animator _animator;
        [SerializeField] private string _explosionName;

        #endregion


        #region Unity lifecycle

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _damageRadius);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag(Tags.PlayerBullet))
                return;

            TakeDamage(_damage);
        }

        #endregion


        #region Public methods

        public void TakeDamage(int damage)
        {
            _collider2D.enabled = false;
            _animator.SetTrigger(_explosionName);
            Explosion();
        }

        #endregion


        #region Private methods

        private void Explosion()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _damageRadius, _layerMask);

            foreach (Collider2D col in colliders)
            {
                IDamageable damageable = col.gameObject.GetComponent<IDamageable>();

                if (!damageable.Equals(null))
                    damageable.TakeDamage(_damage);
            }
        }

        private void Delete() =>
            Destroy(gameObject);

        #endregion
    }
}