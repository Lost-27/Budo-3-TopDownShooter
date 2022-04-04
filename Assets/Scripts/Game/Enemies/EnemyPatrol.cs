using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyPatrol : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private List<Transform> _points;

        private int _currentPointIndex = 0;

        #endregion


        #region Unity lifecycle

        private void OnEnable()
        {
            _enemyMovement.SetTarget(CurrentPoint());
            _enemyMovement.enabled = true;
        }

        private void Update()
        {
            CheckPosition();
        }

        #endregion


        #region Private methods

        private void CheckPosition()
        {
            float distance = Vector3.Distance(CurrentPoint().position, transform.position);

            if (distance > 1f)
                return;

            IncrementIndex();

            _enemyMovement.SetTarget(CurrentPoint());
            _enemyMovement.enabled = true;
        }

        private void IncrementIndex()
        {
            _currentPointIndex++;

            if (_currentPointIndex >= _points.Count)
                _currentPointIndex = 0;
        }

        private Transform CurrentPoint() =>
            _points[_currentPointIndex];

        #endregion
    }
}