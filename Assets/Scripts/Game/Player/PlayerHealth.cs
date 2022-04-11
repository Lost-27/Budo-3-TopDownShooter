using System;
using TDS.Game.Core;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable, IHealth
    {
        #region Variable

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
        }

        #endregion


        #region Public methods
        //DUbliCK ispravit properti!!!!!!!!!!!!!!!!!11:11 sm dz!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public void TakeDamage(int damage)
        {
            if (CurrentHp < 1)
                return;

            CurrentHp -= damage;
            CurrentHp = Mathf.Max(0, CurrentHp);

            OnChanged?.Invoke();
        }

        public void AddLife(int healthPoints)
        {
            if (CurrentHp >= _maxHp)
                return;

            CurrentHp += healthPoints;
            CurrentHp = Mathf.Min(CurrentHp, _maxHp);

            OnChanged?.Invoke();
        }

        #endregion
    }
}