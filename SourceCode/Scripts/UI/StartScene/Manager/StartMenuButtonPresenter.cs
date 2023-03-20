using Assets.Scripts.Save;
using Assets.Scripts.SceneLoader;
using Assets.Scripts.UI.StartScene.StageSelect;
using Assets.Scripts.UI.StratScene.StageSelect;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.StartScene.Manager
{
    public class StartMenuButtonPresenter : MonoBehaviour
    {
        [SerializeField]
        private BaseButton ___StageSelect;

        [SerializeField]
        private BaseButton ___ExitGame;

        [SerializeField]
        private BaseButton ___Tutorial;

        [SerializeField]
        private MainManager ___MainManager;

        [SerializeField]
        private SceneInfoWarehouse ___SceneInfoWareHouse;

        [SerializeField]
        private ConvertPrefab2RegistrationInfo ___ConvertPrefab;


        // Start is called before the first frame update
        void Start()
        {
            ___MainManager.onInitialize.Subscribe(_ => Initialize());
        }

        private void Initialize()
        {
            ___StageSelect.onClicked.Subscribe(_ =>
            {

                ___MainManager.setCurrentSelectMode(SelectMode.StageSelect);
            
            }).AddTo(this);
            ___ExitGame.onClicked.Subscribe(_ => ___MainManager.setCurrentSelectMode( SelectMode.GameExit)).AddTo(this);
            ___Tutorial.onClicked.Subscribe(_ =>
            {
                var __ = goToTutorial();
            });
        }

        public async UniTask goToTutorial()
        {

            SceneDataPack sceneDataPack = new SceneDataPack();
            GameObject stagePrefab = ___SceneInfoWareHouse.getStageInfo(StageList.Stage0);

            sceneDataPack.selectStage = StageList.Stage0;
            sceneDataPack.enemyUnitList = ___ConvertPrefab.convertUnit(stagePrefab);
            sceneDataPack.enemyBlockList = ___ConvertPrefab.convertBlock(stagePrefab);
            sceneDataPack.enemyShipCorePos = ___SceneInfoWareHouse.getStageShipCorePos(StageList.Stage0);
            sceneDataPack.progress = new ManagementData();

            var organizeScene = await SceneLoad.loadAsync<OrganaizeScene.Manager.MainManager>("OrganizeScene");
            organizeScene.setStage(sceneDataPack);
        }
    }
}