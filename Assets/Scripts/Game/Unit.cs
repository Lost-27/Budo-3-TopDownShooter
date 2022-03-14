using UnityEngine;

namespace TDS.Game
{
    public class Unit : MonoBehaviour
    {
        #region Variables
        
        [Header("Lives setting")]
        [SerializeField] protected int _maxLives;
        
        // [Header("Animation settings")]
        // [SerializeField] protected Animator _animator;

        protected int _currentLives;
        protected bool _isDeath;
        
        #endregion
        

        #region Unity lifecycle

        private void Awake()
        {
            _currentLives = _maxLives;
        }

        #endregion
    }
}