using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.SceneLoader {
    public class SceneLoad
    {
        public static async UniTask<ComponentName> loadAsync<ComponentName>(string sceneName, LoadSceneMode mode=LoadSceneMode.Single)
            where ComponentName : Component
        {
            await SceneManager.LoadSceneAsync(sceneName, mode);
            Scene scene = SceneManager.GetSceneByName(sceneName);
            return GetRootComponent<ComponentName>(scene.GetRootGameObjects());
        }

        private static ComponentName GetRootComponent<ComponentName>(GameObject[] gameObjects)
            where ComponentName : Component
        {
            ComponentName targetComponent = null;
            foreach(GameObject gameObject in gameObjects)
            {
                targetComponent = gameObject.GetComponent<ComponentName>();
                if (targetComponent != null) break;
            }
            return targetComponent;
        }
    }


}
