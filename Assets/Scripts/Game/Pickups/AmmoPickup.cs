using Lean.Pool;
using TDS.Game.Player;
using TDS.Utility.Constants;
using UnityEngine;

namespace TDS.Game.Pickups
{
    public class AmmoPickup : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _ammoPoints = 8;

        #endregion


        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.Player))
            {
                col.GetComponent<PlayerAttack>().AddAmmo(_ammoPoints);
                LeanPool.Despawn(gameObject);
            }
        }

        #endregion
    }
}