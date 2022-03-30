using TDS.Infrastructure.SceneHelper;
using TDS.Infrastructure.Services;
using TDS.Utility.Constants;
using UnityEngine;


namespace TDS
{
    [RequireComponent(typeof(Collider2D))]
    public class TransitionZone : MonoBehaviour
    {
        [SerializeField] private string _transitionScene;

        private Collider2D _collider2D;

        private ISceneHelper _sceneHelper;
        private bool _isTriggered;

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            _collider2D.isTrigger = true;
        }

        private void Start()
        {            
            _sceneHelper = Services.Container.Get<ISceneHelper>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isTriggered)
                return;

            if (collision.CompareTag(Tags.Player))
            {
                _sceneHelper.Load(_transitionScene);
                _isTriggered = true;
            }
        }
    }
}
