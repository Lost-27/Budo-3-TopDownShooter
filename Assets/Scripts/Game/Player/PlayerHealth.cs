using System;
using TDS.Game.Core;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable, IHealth
    {
        #region Variable

        [SerializeField] private PlayerDeath _playerDeath;
        [SerializeField] private int _maxHp;

        #endregion

        public event Action OnChanged;
        public int CurrentHp { get; private set; }
        public int MaxHp => _maxHp;


        #region Unity lifecycle

        private void Start()
        {
            CurrentHp = _maxHp;
        }

        #endregion


        #region Public methods

        public void TakeDamage(int damage)
        {
            CurrentHp -= damage;

            OnChanged?.Invoke();

            if (CurrentHp < 1)
                _playerDeath.Death();
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