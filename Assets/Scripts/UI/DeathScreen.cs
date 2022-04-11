using System;
using TDS.Game.Player;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class DeathScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _deathScreen;
        [SerializeField] private Button _restartButton;

        #endregion


        #region Events

        public static event Action OnRestartButtonClicked;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            SetActive(false);

            _restartButton.onClick.AddListener(() => OnRestartButtonClicked?.Invoke());
        }

        #endregion


        #region Public methods

        public void SetActive(bool isActive) =>
            _deathScreen.SetActive(isActive);

        #endregion
    }
}