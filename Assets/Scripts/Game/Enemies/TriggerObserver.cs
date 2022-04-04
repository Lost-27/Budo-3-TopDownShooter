using System;
using UnityEngine;

namespace TDS.Game.Enemies
{
    public class TriggerObserver : MonoBehaviour
    {
        public CircleCollider2D CircleCollider; //?

        #region Events

        public event Action<Collider2D> OnEntered;
        public event Action<Collider2D> OnStayed;
        public event Action<Collider2D> OnExited;

        #endregion


        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D collision) =>
           OnEntered?.Invoke(collision);

        private void OnTriggerStay2D(Collider2D collision) =>
            OnStayed?.Invoke(collision);

        private void OnTriggerExit2D(Collider2D collision) =>
            OnExited?.Invoke(collision);

        #endregion
    }
}
