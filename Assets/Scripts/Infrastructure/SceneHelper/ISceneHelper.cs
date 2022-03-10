using System;

namespace TDS.Infrastructure.SceneHelper
{
    public interface ISceneHelper
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}