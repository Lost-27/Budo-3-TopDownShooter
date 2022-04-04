using TDS.Game.Core;
using UnityEngine;

namespace TDS.Game.UI
{
    public class ActorUI : MonoBehaviour
    {
        #region Variables

        [SerializeField] private HpBar _hpBar;

        private IHealth _actorHealth;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            Construct(GetComponentInParent<IHealth>());
        }

        private void OnDestroy()
        {
            if (_actorHealth != null)
                _actorHealth.OnChanged -= HealthChanged;
        }

        #endregion


        #region Public methods

        public void Construct(IHealth health)
        {
            _actorHealth = health;

            if (_actorHealth != null)
            {
                HealthChanged();
                _actorHealth.OnChanged += HealthChanged;
            }

        }

        #endregion


        #region Private methods

        private void HealthChanged() =>
            _hpBar.SetValues(_actorHealth.CurrentHp, _actorHealth.MaxHp);

        #endregion
    }
}