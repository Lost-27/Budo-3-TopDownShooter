using System.Collections;
using TDS.Game.Enemies;
using TDS.Game.Player;
using TDS.Utility.Constants;
using UnityEngine;

namespace TDS.Game.Objects
{
    public class ExplosiveBarrel : MonoBehaviour
    {
        #region Variables

        [Header("Explosion setting")] 
        [SerializeField] private float _radius;
        [SerializeField] private int _damage = 2;
        
        [Header("Animation")] 
        [SerializeField] private Animator _animator;
        [SerializeField] private string _explosionName;

        #endregion
        

        #region Unity lifecycle

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag(Tags.PlayerBullet))
                return;

            _animator.SetTrigger(_explosionName);
            Explosion();
            StartCoroutine(DelayAndDestroy());
        }

        #endregion


        #region Private methods

        private IEnumerator DelayAndDestroy()
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }

        private void Explosion()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius);

            foreach (Collider2D col in colliders)
            {
                if (col.gameObject == gameObject)
                    continue;

                if (col.gameObject.CompareTag(Tags.Enemy))
                {
                    EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
                    enemyHealth.TakeDamage(_damage);
                }

                if (col.gameObject.CompareTag(Tags.Player))
                {
                    PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
                    playerHealth.TakeDamage(_damage);
                }
            }
        }

        #endregion
    }
}