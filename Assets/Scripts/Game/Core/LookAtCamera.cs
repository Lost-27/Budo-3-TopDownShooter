using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Core
{
    public class LookAtCamera : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Transform _rootTransform;

        private Camera _mainCamera;
        private Vector3 _startPosition;
        private float _yDistance;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _startPosition = transform.localPosition;
            _yDistance = _startPosition.y;
        }

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void LateUpdate()
        {
            Vector3 offset = Vector3.up * _yDistance - _rootTransform.up * _yDistance;
            Vector3 newPos = new Vector3(_startPosition.x + offset.x, _startPosition.y - offset.y, 0);
            transform.localPosition = newPos;

            Quaternion rotation = _mainCamera.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.up);
        }

        #endregion
    }
}
