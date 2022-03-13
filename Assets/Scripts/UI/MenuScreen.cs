using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class MenuScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _playButton;

        #endregion
        

        #region Events

        public static event Action OnPlayButtonClicked;

        #endregion
        

        #region Unity lifecycle

        private void Awake()
        {
            _playButton.onClick.AddListener(() => OnPlayButtonClicked?.Invoke());
        }

        #endregion
    }
}
