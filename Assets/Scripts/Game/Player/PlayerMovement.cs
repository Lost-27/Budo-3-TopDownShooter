using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;

        private Camera _camera;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        #endregion

        
        #region Private methods

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(horizontal, vertical).normalized;
            _rb.velocity = direction * _speed;
        }

        private void Rotate()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPoint = _camera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0;

            Vector3 up = worldPoint - transform.position;
            transform.up = up;
        }

        #endregion
    }
}