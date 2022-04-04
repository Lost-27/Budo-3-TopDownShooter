using UnityEngine;

namespace TDS.Game.Enemies
{
    public class EnemyAttackRange : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyAttack _enemyAttack;
        //[SerializeField] private EnemyDeath _enemyDeath;
        //[SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private MoveToPlayer _moveToPlayer;

        private bool _isInRange;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _triggerObserver.OnEntered += Entered;
            _triggerObserver.OnExited += Exited;
        }

        private void Update()
        {
            if (!_isInRange)
                return;

            _enemyAttack.Attack();
        }

        #endregion


        #region Private methods

        private void Entered(Collider2D obj)
        {
            _isInRange = true;
            _moveToPlayer.enabled = false;
            //_enemyMovement.enabled = false; // !
            //_enemyMovement.ResetMoveAndTarget(); //!
        }

        private void Exited(Collider2D obj)
        {
            _isInRange = false;

            //if ( Proverka)

            _moveToPlayer.enabled = true;
            //_enemyMovement.enabled = true; // !
        }

        #endregion
    }
}
