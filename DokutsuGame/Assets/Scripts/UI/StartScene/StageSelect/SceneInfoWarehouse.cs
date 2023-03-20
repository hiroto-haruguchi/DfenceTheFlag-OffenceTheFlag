using UnityEngine;

namespace Assets.Scripts.UI.StratScene.StageSelect
{
    public class SceneInfoWarehouse : MonoBehaviour
    {
        [SerializeField]
        private GameObject Stage1Prefab;
        [SerializeField]
        private GameObject Stage2Prefab;
        [SerializeField]
        private GameObject Stage3Prefab;
        [SerializeField]
        private GameObject Stage4Prefab;
        [SerializeField]
        private GameObject Stage5Prefab;
        [SerializeField]
        private GameObject Stage6Prefab;
        [SerializeField]
        private GameObject TutorialPrefab;

        private Vector3 Stage1ShipCorePos = new Vector3(10.72f,-6.94f,0f);
        private Vector3 Stage2ShipCorePos = new Vector3(11.35f, -5.74f, 0f);
        private Vector3 Stage3ShipCorePos = new Vector3(10.43f, -6.99f, 0f);
        private Vector3 Stage4ShipCorePos = new Vector3(15.91f, 7.15f, 0f);
        private Vector3 Stage5ShipCorePos = new Vector3(10.56f, 3.13f, 0f);
        private Vector3 Stage6ShipCorePos = new Vector3(7.29f, -7.01f, 0f);
        private Vector3 TutorialCorePos = new Vector3(4.66f, -7.0f, 0.0f);

        public GameObject getStageInfo(StageList stage)
        {
            GameObject stageInfo=null;

            switch(stage){

                case StageList.Stage0:
                    stageInfo = TutorialPrefab;
                    return stageInfo;
                case StageList.Stage1:
                    stageInfo = Stage1Prefab;
                    return stageInfo;
                case StageList.Stage2:
                    stageInfo = Stage2Prefab;
                    return stageInfo;
                case StageList.Stage3:
                    stageInfo = Stage3Prefab;
                    return stageInfo;
                case StageList.Stage4:
                    stageInfo = Stage4Prefab;
                    return stageInfo;
                case StageList.Stage5:
                    stageInfo = Stage5Prefab;
                    return stageInfo;
                case StageList.Stage6:
                    stageInfo = Stage6Prefab;
                    return stageInfo;
                default:
                    return stageInfo;
            }


        }

        public Vector3 getStageShipCorePos(StageList stage)
        {
            Vector3 stageInfo = Vector3.zero;

            switch (stage)
            {
                case StageList.Stage0:
                    stageInfo = TutorialCorePos;
                    return stageInfo;
                case StageList.Stage1:
                    stageInfo = Stage1ShipCorePos;
                    return stageInfo;
                case StageList.Stage2:
                    stageInfo = Stage2ShipCorePos;
                    return stageInfo;
                case StageList.Stage3:
                    stageInfo = Stage3ShipCorePos;
                    return stageInfo;
                case StageList.Stage4:
                    stageInfo = Stage4ShipCorePos;
                    return stageInfo;
                case StageList.Stage5:
                    stageInfo = Stage5ShipCorePos;
                    return stageInfo;
                case StageList.Stage6:
                    stageInfo = Stage6ShipCorePos;
                    return stageInfo;
                default:
                    return stageInfo;
            }

        }
    }

}