using Assets.Scripts.Damage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class UnitRegistrationInfo
    {
        public Vector3 pos { get; private set; }
        public Vector3 angle { get; private set; }
        public int unitId { get; private set; }
        public UnitKindIs unitIs { get; private set; }

        public DogTag myTag { get; private set; }

        public UnitRegistrationInfo(Vector3 position, Vector3 angle, int unitid, UnitKindIs unitis,DogTag tag)
        {
            pos = position;
            this.angle = angle;
            unitId = unitid;
            unitIs = unitis;
            myTag = tag;
        }
    }
}