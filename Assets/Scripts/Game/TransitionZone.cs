using TDS.Infrastructure.Services;
using TDS.Infrastructure.StateMachine;
using TDS.Infrastructure.StateMachine.State;
using TDS.Utility.Constants;
using UnityEngine;

namespace TDS.Game
{
    [RequireComponent(typeof(Collider2D))]
    public class TransitionZone : MonoBehaviour
    {
        #region Variables

        [SerializeField] private string _transitionScene;

        private IGameStateMachine _stateMachine;

        private Collider2D _collider2D;        
        private bool _isTriggered;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            _collider2D.isTrigger = true;
        }

        private void Start()
        {
            _stateMachine = Services.Container.Get<IGameStateMachine>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isTriggered)
                return;

            if (collision.CompareTag(Tags.Player))
            {
                _stateMachine.Enter<LoadingState, string>(_transitionScene);
                _isTriggered = true;
            }
        }

        #endregion
    }
}
