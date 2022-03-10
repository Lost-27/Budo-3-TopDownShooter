using System;
using UnityEngine.SceneManagement;

namespace TDS.Infrastructure.SceneHelper
{
    public class SyncSceneHelper : ISceneHelper
    {
        public void Load(string sceneName, Action onLoaded = null)
        {
            UnityEngine.Debug.Log($"Load SyncSceneHelper");
            SceneManager.LoadScene(sceneName);

            onLoaded?.Invoke();
        }
    }
}