using System;
using System.Collections;
using TDS.Utility;
using TDS.Utility.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS.Infrastructure.SceneHelper
{
    public class AsyncSceneHelper : ISceneHelper
    {
        #region Variables

        private readonly ICoroutineRunner _coroutineRunner;

        #endregion


        #region Constructor

        public AsyncSceneHelper(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        #endregion


        #region Public methods

        public void Load(string sceneName, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));

        #endregion
        

        #region Private methods

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            Debug.Log($"Load AsyncSceneHelper");
            // if (sceneName == SceneTitles.MenuScene)
            // {
            //     yield return new WaitForSeconds(3);
            // }


            AsyncOperation waitScene = SceneManager.LoadSceneAsync(sceneName);

            while (!waitScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }

        #endregion
    }
}