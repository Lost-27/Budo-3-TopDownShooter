using TDS.Game.Player;
using TDS.Utility.Constants;
using UnityEngine;

namespace TDS.Game.Pickups
{
    public class LifePickup : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.Player))
            {
                col.GetComponent<PlayerHealth>().AddLive();
            }
            
            Destroy(gameObject);
        }

        #endregion
    }
}