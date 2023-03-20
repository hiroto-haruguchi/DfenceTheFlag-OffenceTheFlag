using Assets.Scripts.Unit;
using Assets.Scripts.Block;
using Assets.Scripts.Ship;
using System.Collections.Generic;
using Assets.Scripts.Manager;
using UnityEngine;

namespace Assets.Scripts.UI.StartScene.StageSelect
{
    public class ConvertPrefab2RegistrationInfo : MonoBehaviour
    {
        private List<UnitRegistrationInfo> UnitList = new List<UnitRegistrationInfo>();
        private List<BlockRegistrationInfo> BlockList = new List<BlockRegistrationInfo>();
        private Vector3 ShipCorePos = Vector3.zero;

        public List<UnitRegistrationInfo> convertUnit(GameObject target)
        {
            int childNum = target.transform.childCount;
            GameObject child;
            UnitCore core;

            for (int i = 0; i < childNum; i++)
            {
                child = target.transform.GetChild(i).gameObject;
                core = child.GetComponent<UnitCore>();
                if (core == null) continue;

                UnitList.Add(new UnitRegistrationInfo(child.transform.position, child.transform.eulerAngles, 0, core.unitKind, Damage.DogTag.Enemy));
            }

            return UnitList;

        }

        public List<BlockRegistrationInfo> convertBlock(GameObject target)
        {
            int childNum = target.transform.childCount;
            GameObject child;
            BaseBlock core;

            for (int i = 0; i < childNum; i++)
            {
                core = null;

                child = target.transform.GetChild(i).gameObject;
                core = child.GetComponent<BaseBlock>();
                if (core == null) continue;

                BlockList.Add(new BlockRegistrationInfo(child.transform.position, core.blockKind, Damage.DogTag.Enemy));
            }

            return BlockList;
        }

        public Vector3 convertShip(GameObject target)
        {
            int childNum = target.transform.childCount;
            GameObject child;
            ShipCore core;

            for (int i = 0; i < childNum; i++)
            {
                core = null;

                child = target.transform.GetChild(i).gameObject;
                core = child.GetComponent<ShipCore>();
                if (core == null) continue;

                ShipCorePos = child.transform.position;
            }

            return ShipCorePos;
        }

    }

}
