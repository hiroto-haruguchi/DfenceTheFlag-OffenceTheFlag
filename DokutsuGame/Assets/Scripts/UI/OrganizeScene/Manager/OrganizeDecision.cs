using System;
using System.Collections.Generic;
using Assets.Scripts.Manager;
using UniRx;
using UnityEngine;
using Assets.Scripts.SceneLoader;
using Cysharp.Threading.Tasks;
using Assets.Scripts.Save;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class OrganizeDecision : MonoBehaviour
    {
        [SerializeField]
        private MainManager ___MainManager;

        //次のシーンに送る情報 BatlleSceneでの位置と角度
        private List<UnitRegistrationInfo> RegistrationUnits = new List<UnitRegistrationInfo>();
        private List<BlockRegistrationInfo> RegistrationBlocks = new List<BlockRegistrationInfo>();
        private Vector3 ShipCorePos=new Vector3();

        //戻ってきた時に使う情報　OrganizeSceneでの位置と角度
        private List<UnitRegistrationInfo> RegistrationUnitsOrganize = new List<UnitRegistrationInfo>();
        private List<BlockRegistrationInfo> RegistrationBlocksOrganize = new List<BlockRegistrationInfo>();
        private Vector3 ShipCorePosOrganize = new Vector3();
        private ManagementData Progress;


        

        public IObservable<UniRx.Unit> onDecision { get { return OnDecisionSubject; } }
        private Subject<UniRx.Unit> OnDecisionSubject=new Subject<UniRx.Unit>();

        private void Start()
        {
            ___MainManager.onAsyncInitialize.Subscribe(x => Progress = x.progress).AddTo(this);
        }
        public async UniTask decisionOrganizeUnits(StageList stage)
        {
            OnDecisionSubject.OnNext(UniRx.Unit.Default);

            var dataPack = GetComponent<MainManager>().getDataPack();
            dataPack.playerUnitList = RegistrationUnits;
            dataPack.playerBlockList= RegistrationBlocks;
            dataPack.playerShipCorePos = ShipCorePos;

            dataPack.playerUnitListOrganize = RegistrationUnitsOrganize;
            dataPack.playerBlockListOrgainze = RegistrationBlocksOrganize;
            dataPack.playerShipCorePosOrganize = ShipCorePosOrganize;

            var battleScene = await SceneLoad.loadAsync<MainGameManager>("BattleScene");
            battleScene.setList(dataPack,Progress);
        }

        public void addUnitsList(UnitRegistrationInfo battleSceneInfo,UnitRegistrationInfo organizeSceneInfo)
        {
            RegistrationUnits.Add(battleSceneInfo);
            RegistrationUnitsOrganize.Add(organizeSceneInfo);
        }

        public void addBlockList(BlockRegistrationInfo battleSceneInfo, BlockRegistrationInfo organizeSceneInfo)
        {
            RegistrationBlocks.Add(battleSceneInfo);
            RegistrationBlocksOrganize.Add(organizeSceneInfo);
        }

        public void addShipCorePos(Vector3 battleScenePos,Vector3 organizeScenePos)
        {
            ShipCorePos = battleScenePos;
            ShipCorePosOrganize=organizeScenePos;
        }
    }
}