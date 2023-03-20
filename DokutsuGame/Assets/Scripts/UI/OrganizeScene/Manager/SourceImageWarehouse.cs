using Assets.Scripts.Manager;
using Assets.Scripts.Save;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class SourceImageWarehouse : MonoBehaviour
    {
        [SerializeField]
        private MainManager ___MainManager;

        /*Unit Image Sprite*/
        [SerializeField]
        private Sprite ___Nobody;

        [SerializeField]
        private Sprite ___NormalUnit;

        [SerializeField]
        private Sprite ___Dragoon;

        [SerializeField]
        private Sprite ___Ninja;

        [SerializeField]
        private Sprite ___Samurai;

        [SerializeField]
        private Sprite ___Magi;

        [SerializeField]
        private Sprite ___Gunman;

        [SerializeField]
        private Sprite ___Sniper;

        [SerializeField]
        private Sprite ___Launcher;

        [SerializeField]
        private Sprite ___Fighter;

        [SerializeField]
        private Sprite ___Ranger;
        /*******************/

        /*Block Image Sprite*/
        [SerializeField]
        private Sprite ___Block1;

        [SerializeField]
        private Sprite ___Block2;

        [SerializeField]
        private Sprite ___Block3;

        [SerializeField]
        private Sprite ___Block4;

        [SerializeField]
        private Sprite ___Block5;
        /*********************/

        public ManagementData progress;

        private UnitProgressList ___UnitProgressList=new UnitProgressList();

        void Start()
        {
            ___MainManager.onAsyncInitialize.Subscribe(x => progress = x.progress).AddTo(this) ;
        }

        public Sprite setUnitSourceImageSprite(UnitKindIs kind)
        {
            if (kind != UnitKindIs.Nobody && progress.getData(___UnitProgressList.getListData(kind)) == false) return ___Nobody;

            switch (kind) {

                case UnitKindIs.NormalUnit:
                    return ___NormalUnit;
                case UnitKindIs.Dragoon:
                    return ___Dragoon;
                case UnitKindIs.Ninja:
                    return ___Ninja;
                case UnitKindIs.Samurai:
                    return ___Samurai;
                case UnitKindIs.Magi:
                    return ___Magi;
                case UnitKindIs.Gunman:
                    return ___Gunman;
                case UnitKindIs.Sniper:
                    return ___Sniper;
                case UnitKindIs.Launcher:
                    return ___Launcher;
                case UnitKindIs.Fighter:
                    return ___Fighter;
                case UnitKindIs.Ranger:
                    return ___Ranger;
                case UnitKindIs.Nobody:
                    return ___Nobody;
                default:
                    return null;
            }
        }

        public Sprite setBlockSourceImageSprite(BlockKindIs kind)
        {
            switch (kind)
            {
                case BlockKindIs.Block1:
                    return ___Block1;
                case BlockKindIs.Block2:
                    return ___Block2;
                case BlockKindIs.Block3:
                    return ___Block3;
                case BlockKindIs.Block4:
                    return ___Block4;
                case BlockKindIs.Block5:
                    return ___Block5;
                case BlockKindIs.Nobody:
                    return ___Nobody;
                default:
                    return ___Nobody;
            }
        }


    }
}