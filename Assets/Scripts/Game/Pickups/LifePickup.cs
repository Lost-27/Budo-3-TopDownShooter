using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Pickups
{
    public class LifePickup : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Object that entered the trigger : " + other);
            PlayerLives playerLives = other.GetComponent<PlayerLives>();

            if (playerLives == null) return;
            playerLives.AddLive();
            Destroy(gameObject);
        }

        #endregion
    }
}