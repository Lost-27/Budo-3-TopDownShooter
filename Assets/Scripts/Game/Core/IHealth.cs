using System;

namespace TDS.Game.Core
{
    public interface IHealth
    {
        event Action OnChanged;

        int CurrentHp { get; }
        int MaxHp { get; }

        void TakeDamage(int damage);
        void AddLife(int healthPoints);
    }
}