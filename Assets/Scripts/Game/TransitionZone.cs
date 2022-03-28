using TDS.Game.Player;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace TDS
{
    public class TransitionZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player pl))
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
