
using Assets.Scripts.Save;
using Assets.Scripts.SceneLoader;
using Assets.Scripts.UI.StartScene.Manager;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class BackButtonPresenter : MonoBehaviour
    {
        [SerializeField]
        private BaseButton ___BackButton;
        [SerializeField]
        private MainGameManager ___MainGameManager;

        private ManagementData Progress;
        // Start is called before the first frame update
        void Start()
        {
            ___MainGameManager.onAsyncInitialize.Subscribe(x=> Progress = x);

            ___BackButton.onClicked.Subscribe(_ => {

                var __ = backOrganizeScene();

            });
            

        }

        public async UniTask backOrganizeScene()
        {
            var dataPack = ___MainGameManager.getDataPack();

            var organizeScene = await SceneLoad.loadAsync<UI.OrganaizeScene.Manager.MainManager>("OrganizeScene");
            organizeScene.setStage(dataPack);
        }
    }
}