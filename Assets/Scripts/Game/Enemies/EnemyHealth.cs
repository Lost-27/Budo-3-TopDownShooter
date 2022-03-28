using TDS.Game.Core;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        #region Variables

        [SerializeField] private Enemy _enemy;
        [SerializeField] private int _maxHp;

        private int _currentHp;

        #endregion
        

        #region Unity lifecycle

        private void Start()
        {
            _currentHp = _maxHp;
        }

        #endregion
        

        #region Public methods

        public void TakeDamage(int damage)
        {
            _currentHp -= damage;

            if (_currentHp < 1)
                _enemy.Death();
        }

        #endregion
    }
}