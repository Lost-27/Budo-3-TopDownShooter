using TDS.Game.Player;
using TMPro;
using UnityEngine;

namespace TDS.Game.UI
{
    public class AmmoUI : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _dynamicAmmoLabel;

        private PlayerAttack _playerAttack;

        #endregion


        #region Unity lifecycle 

        private void OnDestroy()
        {
            if (_playerAttack != null)
                _playerAttack.OnAmmoChanged -= UpdateAmmoLabel;
        }

        #endregion


        #region Public methods

        public void Construct(PlayerAttack playerAttack)
        {
            _playerAttack = playerAttack;

            _playerAttack.OnAmmoChanged += UpdateAmmoLabel;
            UpdateAmmoLabel();
        }

        #endregion


        #region Private methods

        private void UpdateAmmoLabel() => 
            _dynamicAmmoLabel.text = _playerAttack.CurrentAmmo.ToString();

        #endregion
    }
}