using System;
using Pathfinding;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class AIEnemyMovement : EnemyMovement
    {
        #region Variables

        [Header(nameof(AIEnemyMovement))] 
        [SerializeField] private AIDestinationSetter _destinationSetter;
        [SerializeField] private AIBase _aiBase;

        #endregion
        

        #region Unity lifecycle

        private void Awake()
        {
            _aiBase.maxSpeed = _speed;
        }

        private void OnEnable()
        {
            _aiBase.enabled = true;
        }

        private void OnDisable()
        {
            _aiBase.enabled = false;
        }

        #endregion
        

        #region Public methods

        public override void ResetMoveAndTarget()
        {
            _destinationSetter.target = null;
        }

        public override void SetTarget(Transform targetTransform)
        {
            _destinationSetter.target = targetTransform;
        }

        #endregion
    }
}