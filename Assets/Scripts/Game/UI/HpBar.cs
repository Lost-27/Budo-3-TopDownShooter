using UnityEngine.UI;
using UnityEngine;

namespace TDS.Game.UI
{
    public class HpBar : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Slider _hpSlider;

        #endregion


        #region Public methods

        public void SetValues(int currentValue, int maxValue)
        {
            if (maxValue == 0)
                return;

            _hpSlider.maxValue = maxValue;
            _hpSlider.value = currentValue;
        }

        #endregion
    }
}
