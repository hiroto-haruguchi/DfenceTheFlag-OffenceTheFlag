using Assets.Scripts.Manager;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.Mouse {
    public class MouseComponent : MonoBehaviour
    {
        [SerializeField]
        private Assets.Scripts.UI.OrganaizeScene.Manager.UnitProviderUI ___UnitProvider;
        [SerializeField]
        private Assets.Scripts.UI.OrganaizeScene.Manager.BlockProviderUI ___BlockProvider;

        public MouseState State { get; set; } = MouseState.Normal;
        private UnitKindIs CreateUnit=UnitKindIs.Nobody;
        private BlockKindIs CreateBlock=BlockKindIs.Nobody;

        public void setCreateUnit(UnitKindIs Iam)
        {
            if (State != MouseState.Hold) State = MouseState.Holdable;
            CreateUnit = Iam;
        }

        public void removeCreateUnit()
        {
            if (State != MouseState.Hold) State = MouseState.Normal;
            CreateUnit = UnitKindIs.Nobody;
        }

        public void unitCreate() 
        {
            if (State == MouseState.Holdable)
            {
                if (CreateUnit != UnitKindIs.Nobody)
                {
                    State = MouseState.Hold;
                    ___UnitProvider.createUnit(CreateUnit);
                    CreateUnit = UnitKindIs.Nobody;
                }

            }

        }

        public void setCreateBlock(BlockKindIs Iam)
        {
            if (State != MouseState.Hold) State = MouseState.Holdable;
            CreateBlock = Iam;
        }

        public void removeCreateBlock()
        {
            if (State != MouseState.Hold) State = MouseState.Normal;
            CreateBlock = BlockKindIs.Nobody;
        }

        public void blockCreate()
        {
            if (State == MouseState.Holdable)
            {

                State = MouseState.Hold;
                if (CreateBlock != BlockKindIs.Nobody)
                {
                    ___BlockProvider.createBlock(CreateBlock);
                    CreateBlock = BlockKindIs.Nobody;
                }

            }

        }

    }
}