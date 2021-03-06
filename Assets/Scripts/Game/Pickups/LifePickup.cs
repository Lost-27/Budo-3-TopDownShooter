using Lean.Pool;
using TDS.Game.Player;
using TDS.Utility.Constants;
using UnityEngine;

namespace TDS.Game.Pickups
{
    public class LifePickup : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _healthPoints = 1;

        #endregion


        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.Player))
            {
                col.GetComponent<PlayerHealth>().AddLife(_healthPoints);
                LeanPool.Despawn(gameObject);
            }
        }

        #endregion
    }
}