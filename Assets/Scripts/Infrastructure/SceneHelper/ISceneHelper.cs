using System;
using TDS.Infrastructure.Services;

namespace TDS.Infrastructure.SceneHelper
{
    public interface ISceneHelper : IService
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}