using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Pickups
{
    public class LifePickup : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController == null) return;
            playerController.AddLive();
            Destroy(gameObject);
        }

        #endregion
    }
}