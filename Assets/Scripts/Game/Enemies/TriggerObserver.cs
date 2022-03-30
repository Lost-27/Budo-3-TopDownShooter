using System;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider2D> OnEntered;
        public event Action<Collider2D> OnExited;

        private void OnTriggerEnter2D(Collider2D collision) => 
            OnEntered?.Invoke(collision);

        private void OnTriggerExit2D(Collider2D collision) =>
            OnExited?.Invoke(collision);
    }
}
