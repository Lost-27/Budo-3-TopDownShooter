using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _attackName;
        [SerializeField] private string _speedName;
        [SerializeField] private string _deathName;

        #endregion
        

        #region Unity lifecycle

        private void Update() =>
            PlayMove();

        #endregion
        

        #region Public methods

        public void PlayAttack() =>
            _animator.SetTrigger(_attackName);
        public void PlayDeath() =>
            _animator.SetTrigger(_deathName);

        #endregion
        

        #region Private methods

        private void PlayMove() =>
            _animator.SetFloat(_speedName, _rb.velocity.magnitude);

        #endregion
    }
}
