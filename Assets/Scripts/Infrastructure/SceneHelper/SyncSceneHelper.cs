using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS.Infrastructure.SceneHelper
{
    public class SyncSceneHelper : ISceneHelper
    {
        #region Public methods

        public void Load(string sceneName, Action onLoaded = null)
        {
            Debug.Log($"Load SyncSceneHelper");
            SceneManager.LoadScene(sceneName);

            onLoaded?.Invoke();
        }

        #endregion
    }
}