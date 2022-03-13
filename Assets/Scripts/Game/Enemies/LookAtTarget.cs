using UnityEngine;

namespace TDS.Game.Enemies
{
    public class LookAtTarget : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _target;

        #endregion


        #region Unity lifecycle

        private void Update()
        {
            if (_target != null)
            {
                RotateTowardsTarget();
            }
        }

        #endregion


        #region Private methods

        private void RotateTowardsTarget()
        {
            //Vector2 direction = target.position - transform.position;
            //direction.Normalize();
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            Vector2 directionToTarget = _target.position - transform.position;
            transform.up = directionToTarget;
        }

        #endregion
    }
}