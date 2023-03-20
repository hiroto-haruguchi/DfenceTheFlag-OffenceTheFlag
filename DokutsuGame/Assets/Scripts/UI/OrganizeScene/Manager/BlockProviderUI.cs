using Assets.Scripts.Manager;
using Assets.Scripts.UI.OrganaizeScene.SelectUnit;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class BlockProviderUI : MonoBehaviour
    {
        [SerializeField]
        private MoneyCounter ___MoneyCounter;

        [SerializeField]
        private GameObject ___Block1;

        [SerializeField]
        private GameObject ___Block2;

        [SerializeField]
        private GameObject ___Block3;

        [SerializeField]
        private GameObject ___Block4;

        [SerializeField]
        private GameObject ___Block5;

        public IReactiveCollection<GameObject> blockList { get { return BlockList; } }

        private readonly ReactiveCollection<GameObject> BlockList = new ReactiveCollection<GameObject>();

        public void createBlock(BlockKindIs kind)
        {

            GetBlock(kind);
        }

        public void createBlockBack(BlockRegistrationInfo info)
        {
            var block = Instantiate(SelectBlock(info.iAm), info.pos, Quaternion.identity);
            var blockUi = block.GetComponent<BaseBlockUI>();

            blockUi.iAm = info.iAm;
            blockUi.setState(UnitState.Normal);

            if (___MoneyCounter.canBuy(blockUi.getCost()) == false)
            {
                Destroy(block);
                return;

            }
            else ___MoneyCounter.setMoney(-blockUi.getCost());

            BlockList.Add(block);
        }

        private void GetBlock(BlockKindIs kind)
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 cursorToWorld = Camera.main.ScreenToWorldPoint(mousePosition);

            var block = Instantiate(SelectBlock(kind), cursorToWorld, Quaternion.identity);
            var blockUi = block.GetComponent<BaseBlockUI>();

            blockUi.iAm = kind;

            if (___MoneyCounter.canBuy(blockUi.getCost()) == false)
            {
                Destroy(block);
                return;

            }
            else ___MoneyCounter.setMoney(-blockUi.getCost());

            BlockList.Add(block);
            

        }
        private GameObject SelectBlock(BlockKindIs kind)
        {
            GameObject blockObj = null;

            switch (kind)
            {
                case BlockKindIs.Nobody:
                    return blockObj;
                case BlockKindIs.Block1:
                    blockObj = ___Block1;
                    return blockObj;
                case BlockKindIs.Block2:
                    blockObj = ___Block2;
                    return blockObj;
                case BlockKindIs.Block3:
                    blockObj = ___Block3;
                    return blockObj;
                case BlockKindIs.Block4:
                    blockObj = ___Block4;
                    return blockObj;
                case BlockKindIs.Block5:
                    blockObj = ___Block5;
                    return blockObj;
                default:
                    return blockObj;
            }

        }
    }
}
