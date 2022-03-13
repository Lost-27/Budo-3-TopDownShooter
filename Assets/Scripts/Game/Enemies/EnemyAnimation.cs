using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator _animator;
        [SerializeField] private string _deathName;

        #endregion


        #region Public methods

        public void EnemyDeath() =>
            _animator.SetTrigger(_deathName);

        #endregion
    }
}