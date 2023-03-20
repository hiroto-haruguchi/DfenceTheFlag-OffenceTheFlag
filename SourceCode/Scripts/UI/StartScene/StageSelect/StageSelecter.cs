using Assets.Scripts.SceneLoader;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Assets.Scripts.UI.StartScene.Manager;
using Assets.Scripts.UI.StratScene.StageSelect;
using Assets.Scripts.Save;
using System.IO;
using System;

namespace Assets.Scripts.UI.StartScene.StageSelect
{
    public class StageSelecter : MonoBehaviour
    {
        [SerializeField]
        private StageImageWareHouse ___WareHouse;
        [SerializeField]
        private Image ___MyImage;
        [SerializeField]
        private SceneInfoWarehouse ___SceneInfoWareHouse;
        [SerializeField]
        private ConvertPrefab2RegistrationInfo ___ConvertPrefab;

        public IObservable<StageList> currentStage { get { return CurrentStage; } }
        private ReactiveProperty<StageList> CurrentStage = new ReactiveProperty<StageList>(StageList.Stage1);

        private ManagementData ProgressData = new ManagementData();

        // Start is called before the first frame update
        void Start()
        {
            string filePath = Application.dataPath + "/savedata.xml";
            if (File.Exists(filePath))
            {
                ProgressData = DataUtil.deserialize<ManagementData>(filePath);
            }
            else
            {
                DataUtil.saveXML(filePath, ProgressData);
            }

            CurrentStage.Subscribe(x => SetImage(x));
        }

        public void changeStageList(listDirection direction)
        {

            int listLen = System.Enum.GetValues(typeof(StageList)).Length-1;
            int setStage = ((int)CurrentStage.Value + (int)direction) % listLen;

            if (setStage <= 0) setStage = listLen;
            else if (setStage > 6) setStage = 1;
            Debug.Log(setStage);

            CurrentStage.Value = (StageList)setStage;
        }

        private void SetImage(StageList stage)
        {

            ___MyImage.sprite = ___WareHouse.getSprite(stage,ProgressData);
        }

        public async UniTask sceneLoad()
        {
            if (CurrentStage.Value != StageList.Stage1 && ProgressData.getData(CurrentStage.Value - 1) == false) return;

            SceneDataPack sceneDataPack = new SceneDataPack();
            GameObject stagePrefab = ___SceneInfoWareHouse.getStageInfo(CurrentStage.Value);

            sceneDataPack.selectStage=CurrentStage.Value;
            sceneDataPack.enemyUnitList = ___ConvertPrefab.convertUnit(stagePrefab);
            sceneDataPack.enemyBlockList = ___ConvertPrefab.convertBlock(stagePrefab);
            sceneDataPack.enemyShipCorePos = ___SceneInfoWareHouse.getStageShipCorePos(CurrentStage.Value);
            sceneDataPack.progress = ProgressData;

            var organizeScene = await SceneLoad.loadAsync<OrganaizeScene.Manager.MainManager>("OrganizeScene");
            organizeScene.setStage(sceneDataPack);
        }

        public enum listDirection
        {
            Forward=1,
            Backward=-1
        }
    }
}