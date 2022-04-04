using TDS.Game.Player;
using System;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAgro : MonoBehaviour
    {
        #region Variables

        [Range(0, 360)] 
        [SerializeField] private float viewAngle;

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyFollow _enemyFollow;

        [Header("Raycast")] [SerializeField] private LayerMask _raycastMask;

        private bool _isFollow;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _triggerObserver.OnStayed += Stayed;
            _triggerObserver.OnExited += Exited;
        }

        private void OnDrawGizmosSelected()
        {
            Vector3 viewAngleA = DirectionFromAngle(-viewAngle / 2, false);
            Vector3 viewAngleB = DirectionFromAngle(viewAngle / 2, false);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + viewAngleA * _triggerObserver.CircleCollider.radius);
            Gizmos.DrawLine(transform.position, transform.position + viewAngleB * _triggerObserver.CircleCollider.radius);
        }

        #endregion


        #region Private methods

        private Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
                angleInDegrees -= transform.eulerAngles.z;

            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
        }

        private void Stayed(Collider2D obj)
        {
            if (_isFollow)
                return;

            Vector3 direction = obj.transform.position - transform.position;


            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, direction.magnitude, _raycastMask);

            Debug.DrawRay(transform.position, direction, Color.red);
            Debug.Log($"Hit {hit2D.collider}");

            if (hit2D.collider != null)
                return;

            _enemyFollow.enabled = true;
        }

        private void Exited(Collider2D obj)
        {
            _enemyFollow.enabled = false;
            _isFollow = false;
        }

        #endregion
    }
}