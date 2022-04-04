using System;
using TDS.Game.Player;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class DeathScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerDeath _playerDeath;
        [SerializeField] private GameObject _deathScreen;
        [SerializeField] private Button _restartButton;

        #endregion


        #region Events

        public static event Action OnRestartButtonClicked;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _deathScreen.SetActive(false);
            _restartButton.onClick.AddListener(() => OnRestartButtonClicked?.Invoke());
        }

        private void OnEnable()
        {
            _playerDeath.OnPlayerDeath += PlayerDeath;
        }

        private void OnDisable()
        {
            _playerDeath.OnPlayerDeath -= PlayerDeath;
        }

        #endregion


        #region Private methods

        private void PlayerDeath()
        {
            _deathScreen.SetActive(true);
        }

        #endregion
    }
}