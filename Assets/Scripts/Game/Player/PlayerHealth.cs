using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        #region Variable

        [SerializeField] private Player _player;
        [SerializeField] private int _maxHp;

        public int CurrentHp;

        #endregion
        

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

            if (CurrentHp < 1)
                _player.Death();
        }
        
        public void AddLive()
        {
            if (CurrentHp >= _maxHp)
                return;
        
            CurrentHp++;
        }

        #endregion
    }
}