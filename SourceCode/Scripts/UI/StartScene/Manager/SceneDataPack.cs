using Assets.Scripts.Manager;
using Assets.Scripts.Save;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.StartScene.Manager
{
    public struct SceneDataPack
    {
        public StageList selectStage;
        public ManagementData progress;
        
        //BattleScene Unit,Block and ShipCore Position and Anglue Data
        public List<UnitRegistrationInfo> playerUnitList;
        public List<BlockRegistrationInfo> playerBlockList;
        public Vector3 playerShipCorePos;

        //OrganizeScene Unit,Block and ShipCore Position and Anglue Data
        public List<UnitRegistrationInfo> playerUnitListOrganize;
        public List<BlockRegistrationInfo> playerBlockListOrgainze;
        public Vector3 playerShipCorePosOrganize;

        public List<UnitRegistrationInfo> enemyUnitList;
        public List<BlockRegistrationInfo> enemyBlockList;
        public Vector3 enemyShipCorePos;
    } 
}