using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        public static event Action OnPlayButtonClicked;

        private void Awake()
        {
            _playButton.onClick.AddListener(() => OnPlayButtonClicked?.Invoke());
        }
    }
}
