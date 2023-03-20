using System.Collections.Generic;
using Assets.Scripts.Damage;
using Assets.Scripts.Unit;
using Assets.Scripts.Block;
using Assets.Scripts.Ship;
using UnityEngine;
using Assets.Scripts.UI.StartScene.Manager;
using Assets.Scripts.Save;
using System;
using UniRx;

namespace Assets.Scripts.Manager
{
    public class MainGameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject ___Ship;

        [SerializeField]
        private GameObject ___ShipCoreEnemy;

        [SerializeField]
        private GameObject ___ShipCorePlayer;

        [SerializeField]
        private GameObject ___Stage12BackGround;
        [SerializeField]
        private GameObject ___Stage34BackGround;
        [SerializeField]
        private GameObject ___Stage56BackGround;

        [SerializeField]
        private GameObject ___TutorialObject;
        
        private UnitProvider UnitProvider;
        private BlockProvider BlockProvider;

        private GameObject UnitObject;
        private GameObject BlockObject;

        public IObservable<ManagementData> onAsyncInitialize { get { return OnAsyncInitialize; } }
        private AsyncSubject<ManagementData> OnAsyncInitialize = new AsyncSubject<ManagementData>();

        private List<UnitRegistrationInfo> UnitList = new List<UnitRegistrationInfo>();
        private List<BlockRegistrationInfo> BlockList = new List<BlockRegistrationInfo>();
        private Vector3 ShipCorePos = new Vector3(-14.5f, -7.03f, 0);

        private List<UnitRegistrationInfo> EnemyUnitList;
        private List<BlockRegistrationInfo> EnemyBlockList;
        private Vector3 EnemyShipCorePos;

        private StageList SelectStage = new StageList();

        private ManagementData Progress;

        private SceneDataPack SceneDataPack;


        // Start is called before the first frame update
        void Start()
        {


            UnitProvider = GetComponent<UnitProvider>();
            BlockProvider = GetComponent<BlockProvider>();
            if (SceneDataPack.selectStage == StageList.Stage0) ___TutorialObject.SetActive(true);


            //Set up ShipCore and Ship

                //Set up Friend ShipCore
            ___ShipCorePlayer.GetComponent<ShipCore>().initializeShipCore(ShipCorePos, DogTag.Friend);
            ___ShipCorePlayer.transform.SetParent(___Ship.transform, true);

            //Set up EnemyShipCore
            ___ShipCoreEnemy.GetComponent<ShipCore>().initializeShipCore(EnemyShipCorePos, DogTag.Enemy);

            //Set up PlayerUnits
            foreach (var it in UnitList)
            {
                UnitObject = UnitProvider.createUnit(it);
                var UnitCore = UnitObject.GetComponent<UnitCore>();
                UnitObject.transform.SetParent(___Ship.transform, true);
                UnitCore.initializeUnit(it);

            }

            //Set up EnemyUnits
            foreach (var it in EnemyUnitList)
            {

                UnitObject = UnitProvider.createUnit(it);
                UnitObject.transform.localScale = new Vector3(-UnitObject.transform.localScale.x, UnitObject.transform.localScale.y, UnitObject.transform.localScale.z);
                var UnitCore = UnitObject.GetComponent<UnitCore>();
                UnitCore.initializeUnit(it);

            }

            //Set up PlaerBlocks
            foreach (var it in BlockList)
            {
                BlockObject = BlockProvider.createBlock(it);
                var BlockBase = BlockObject.GetComponent<BaseBlock>();
                BlockBase.initializeBlock(it);
                BlockObject.transform.SetParent(___Ship.transform, true);
            }

            //Set up EnemyBlocks
            foreach (var it in EnemyBlockList)
            {
                BlockObject = BlockProvider.createBlock(it);
                var BlockBase = BlockObject.GetComponent<BaseBlock>();
                BlockBase.initializeBlock(it);
            }

            SetBackGround(SelectStage);

            OnAsyncInitialize.OnNext(Progress);
            OnAsyncInitialize.OnCompleted();
        }

        public void setList(SceneDataPack dataPack,ManagementData progress)
        {
            SceneDataPack = dataPack;
            UnitList = dataPack.playerUnitList;
            BlockList = dataPack.playerBlockList;
            ShipCorePos = dataPack.playerShipCorePos;
            SelectStage = dataPack.selectStage;

            EnemyUnitList = dataPack.enemyUnitList;
            EnemyBlockList = dataPack.enemyBlockList;
            EnemyShipCorePos = dataPack.enemyShipCorePos;
            Progress= progress;
            Progress.selectStage = SelectStage;

        }

        private void SetBackGround(StageList stage)
        {
            if (stage == StageList.Stage0||
                stage == StageList.Stage1 ||
                stage == StageList.Stage2)
            {
                ___Stage12BackGround.SetActive(true);

            }
            else if (stage == StageList.Stage3 ||
                     stage == StageList.Stage4)
            {
                ___Stage34BackGround.SetActive(true);

            }
            else if (stage == StageList.Stage5 ||
                     stage == StageList.Stage6)
            {
                ___Stage56BackGround.SetActive(true);
            }

        }

        public SceneDataPack getDataPack()
        {
            return SceneDataPack;
        }
    }
}