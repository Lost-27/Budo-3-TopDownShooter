using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;

        [SerializeField] private Animator _animator;
        [SerializeField] private string _attackName;
        [SerializeField] private string _speedName;
        [SerializeField] private string _deathName;

        #endregion


        #region Public methods

        public void EnemyAttack() =>
            _animator.SetTrigger(_attackName);
        
        public void EnemyIdle(float speed) =>
            _animator.SetFloat(_speedName, speed);

        public void EnemyMove(float speed) =>
           _animator.SetFloat(_speedName, speed);

        public void EnemyDeath() =>
            _animator.SetTrigger(_deathName);

        #endregion       
    }
}