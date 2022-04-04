using System;
using TDS.Game.Core;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyHealth : MonoBehaviour, IDamageable, IHealth
    {
        #region Variables

        [SerializeField] private EnemyDeath _enemyDeath;
        [SerializeField] private int _maxHp;

        #endregion


        #region Events

        public event Action OnChanged;

        #endregion


        #region Properties

        public int CurrentHp { get; private set; }
        public int MaxHp => _maxHp;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            CurrentHp = _maxHp;
            OnChanged?.Invoke();
        }

        #endregion


        #region Public methods

        public void TakeDamage(int damage)
        {
            CurrentHp -= damage;

            OnChanged?.Invoke();

            if (CurrentHp < 1)
                _enemyDeath.Death();
        }

        public void AddLife(int healthPoints)
        {
            if (CurrentHp >= _maxHp)
                return;

            CurrentHp += healthPoints;

            OnChanged?.Invoke();
        }

        #endregion
    }
}