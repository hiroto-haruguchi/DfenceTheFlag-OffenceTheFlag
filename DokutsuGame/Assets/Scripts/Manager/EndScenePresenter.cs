using Assets.Scripts.UI.StartScene.Manager;
using Assets.Scripts.SceneLoader;
using UniRx;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Manager
{
    public class EndScenePresenter : MonoBehaviour
    {
        [SerializeField]
        private BaseButton ___StageSelect;
        [SerializeField]
        private BaseButton ___StartMenu;

        // Start is called before the first frame update
        void Start()
        {
            ___StageSelect.onClicked.Subscribe(_ =>
            {
                
                var __=StageSelectSceneLoad();
            });

            ___StartMenu.onClicked.Subscribe(_ => 
            {
                var __ = StartMenuSceneLoad();
            });

        }

        private async UniTask StageSelectSceneLoad()
        {

            var startMenuScene = await SceneLoad.loadAsync<Assets.Scripts.UI.StartScene.Manager.MainManager>("StartScene");
            startMenuScene.setCurrentSelectMode(SelectMode.StageSelect);

        }

        private async UniTask StartMenuSceneLoad()
        {
            var startMenuScene = await SceneLoad.loadAsync<Assets.Scripts.UI.StartScene.Manager.MainManager>("StartScene");
            startMenuScene.setCurrentSelectMode(SelectMode.Start);

        }
    }
}