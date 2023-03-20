using Assets.Scripts.SceneLoader;
using Assets.Scripts.UI.StartScene.Manager;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.OrganizeScene.Manager
{
    public class BackStartScene : MonoBehaviour
    {
        [SerializeField]
        private BaseButton ___BackButton;
        // Start is called before the first frame update
        void Start()
        {
            ___BackButton.onClicked.Subscribe(_ => {

                var __ = BackOrganizeScene();

            }).AddTo(this);
        }
        public async UniTask BackOrganizeScene()
        { 

            var startScene = await SceneLoad.loadAsync<UI.StartScene.Manager.MainManager>("StartScene");
            startScene.setCurrentSelectMode(SelectMode.StageSelect);
        }
    }
}