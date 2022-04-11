using System;
using TDS.Game.Player;
using TMPro;
using UnityEngine;

namespace TDS.Game.UI
{
    public class AmmoUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _dynamicAmmoLabel;
        [SerializeField] private PlayerAttack _playerAttack;

        private void OnEnable()
        {
            _playerAttack.OnAmmoChanged += UpdateAmmoLabel;
        }


        private void OnDisable()
        {
            _playerAttack.OnAmmoChanged -= UpdateAmmoLabel;
        }

        private void UpdateAmmoLabel()
        {
            _dynamicAmmoLabel.text = _playerAttack.CurrentAmmo.ToString();
        }
    }
}