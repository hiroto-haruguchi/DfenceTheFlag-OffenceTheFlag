using Assets.Scripts.Save;
using UnityEngine;

namespace Assets.Scripts.UI.StartScene.StageSelect
{
    public class StageImageWareHouse : MonoBehaviour
    {
        [SerializeField]
        private Sprite ___Stage1;
        [SerializeField]
        private Sprite ___Stage2;
        [SerializeField]
        private Sprite ___Stage3;
        [SerializeField]
        private Sprite ___Stage4;
        [SerializeField]
        private Sprite ___Stage5;
        [SerializeField]
        private Sprite ___Stage6;

        [SerializeField]
        private Sprite ___Stage2Unlock;
        [SerializeField]
        private Sprite ___Stage3UnLock;
        [SerializeField]
        private Sprite ___Stage4UnLock;
        [SerializeField]
        private Sprite ___Stage5UnLock;
        [SerializeField]
        private Sprite ___Stage6UnLock;

        public Sprite getSprite(StageList stage,ManagementData data)
        {
            Sprite stageSprite;

            if (stage==StageList.Stage1||data.getData(stage-1) == true)
            {

                switch (stage)
                {
                    case StageList.Stage1:
                        stageSprite = ___Stage1;
                        break;
                    case StageList.Stage2:
                        stageSprite = ___Stage2;
                        break;
                    case StageList.Stage3:
                        stageSprite = ___Stage3;
                        break;
                    case StageList.Stage4:
                        stageSprite = ___Stage4;
                        break;
                    case StageList.Stage5:
                        stageSprite = ___Stage5;
                        break;
                    case StageList.Stage6:
                        stageSprite = ___Stage6;
                        break;
                    default:
                        stageSprite = ___Stage3;
                        break;
                }
            }
            else
            {
                switch (stage)
                {
                    case StageList.Stage1:
                        stageSprite = ___Stage1;
                        break;
                    case StageList.Stage2:
                        stageSprite = ___Stage2Unlock;
                        break;
                    case StageList.Stage3:
                        stageSprite = ___Stage3UnLock;
                        break;
                    case StageList.Stage4:
                        stageSprite = ___Stage4UnLock;
                        break;
                    case StageList.Stage5:
                        stageSprite = ___Stage5UnLock;
                        break;
                    case StageList.Stage6:
                        stageSprite = ___Stage6UnLock;
                        break;
                    default:
                        stageSprite = ___Stage3UnLock;
                        break;
                }

            }

            return stageSprite;
        }
    }
}