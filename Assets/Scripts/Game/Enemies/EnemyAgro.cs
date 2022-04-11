using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAgro : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerAgro;
        [SerializeField] private TriggerObserver _triggerInstantAgro;
        [SerializeField] private EnemyFollow _enemyFollow;

        [Header("View Zone")] 
        [SerializeField] private CircleCollider2D _circleCollider;

        [Range(0, 360)] 
        [SerializeField] private float _viewAngle;

        [Header("Raycast")] 
        [SerializeField] private LayerMask _raycastMask;

        private bool _isFollow;

        #endregion


        #region Properties

        public float ViewAngle => _viewAngle;
        public CircleCollider2D CircleCollider => _circleCollider;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _triggerAgro.OnStayed += Stayed;
            _triggerAgro.OnExited += Exited;
            _triggerInstantAgro.OnEntered += Entered;
        }


        private void OnDrawGizmosSelected()
        {
            Vector3 viewAngleA = DirectionFromAngle(-_viewAngle / 2, false);
            Vector3 viewAngleB = DirectionFromAngle(_viewAngle / 2, false);

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + viewAngleA * _circleCollider.radius);
            Gizmos.DrawLine(transform.position, transform.position + viewAngleB * _circleCollider.radius);
        }

        #endregion


        #region Public methods

        public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
                angleInDegrees -= transform.eulerAngles.z;

            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
        }

        #endregion


        #region Private methods

        private void Entered(Collider2D obj)
        {
            Vector3 direction = obj.transform.position - transform.position;
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, direction.magnitude, _raycastMask);

            Debug.DrawRay(transform.position, direction, Color.red);
            Debug.Log($"Hit {hit2D.collider}");

            if (hit2D.collider != null)
                return;

            _enemyFollow.enabled = true;
        }

        private void Stayed(Collider2D obj)
        {
            if (_isFollow)
                return;

            Vector3 direction = obj.transform.position - transform.position;
            Vector3 lookAt = transform.up;

            float angle = Vector3.Angle(lookAt, direction);

            if (angle > _viewAngle * 0.5f)
                return;

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