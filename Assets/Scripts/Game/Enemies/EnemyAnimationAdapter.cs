using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAnimationAdapter : MonoBehaviour
    {
        #region Variables

        [SerializeField] private EnemyAttack _enemyAttack;

        #endregion


        #region Public methods

        public void AppleDamage()
        {
            _enemyAttack.AppleDamage();
        }

        #endregion
    }
}