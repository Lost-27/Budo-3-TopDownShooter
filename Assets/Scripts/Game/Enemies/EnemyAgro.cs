using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAgro : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerAgro;
        [SerializeField] private TriggerObserver _triggerInstantAgro;
        [SerializeField] private EnemyFollow _enemyFollow;
        [SerializeField] private EnemyIdleBehaviour _idleBehaviour;

        [Header("View Zone")]
        [SerializeField] private CircleCollider2D _circleCollider;

        [Range(0, 360)]
        [SerializeField] private float _viewAngle;

        [Header("Raycast")]
        [SerializeField] private LayerMask _raycastMask;        

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

            if (hit2D.collider != null)
                return;

            Follow(true);
        }

        private void Stayed(Collider2D obj)
        {
            if (_enemyFollow.enabled)
                return;

            Vector3 direction = obj.transform.position - transform.position;
            Vector3 lookAt = transform.up;

            float angle = Vector3.Angle(lookAt, direction);

            if (angle > _viewAngle * 0.5f)
                return;

            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, direction.magnitude, _raycastMask);            

            if (hit2D.collider != null)
                return;

            Follow(true);
        }

        private void Exited(Collider2D obj)
        {
            Follow(false);
        }

        private void Follow(bool isFallow)
        {
            _enemyFollow.enabled = isFallow;
            EnableIdle(!isFallow);
        }

        private void EnableIdle(bool isEnabled)
        {
            if (_idleBehaviour != null)
                _idleBehaviour.enabled = isEnabled;
        }

        #endregion
    }
}