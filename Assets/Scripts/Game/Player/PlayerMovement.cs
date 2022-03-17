using TDS.Game.Input;
using TDS.Infrastructure.Services;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;

        private IInputService _inputService;
        private Camera _camera;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _camera = Camera.main;
            _inputService = Services.Container.Get<IInputService>();
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        #endregion


        #region Public methods

        public void ResetMove()
        {
            _rb.velocity = Vector2.zero;
        }

        #endregion


        #region Private methods

        private void Move()
        {
            Vector2 direction = _inputService.Axis.normalized;
            _rb.velocity = direction * _speed;
        }

        private void Rotate()
        {
            Vector3 mousePosition = _inputService.MousePosition;
            Vector3 worldPoint = _camera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0;

            Vector3 up = worldPoint - transform.position;
            transform.up = up;
        }

        #endregion
    }
}