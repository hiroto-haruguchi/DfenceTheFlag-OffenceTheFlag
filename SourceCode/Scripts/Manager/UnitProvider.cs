using Assets.Scripts.Unit;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class UnitProvider : MonoBehaviour
    {
        [SerializeField]
        private GameObject ___NormalUnit;

        [SerializeField]
        private GameObject ___Dragoon;

        [SerializeField]
        private GameObject ___Ninja;

        [SerializeField]
        private GameObject ___Samurai;

        [SerializeField]
        private GameObject ___Magi;

        [SerializeField]
        private GameObject ___Gunman;

        [SerializeField]
        private GameObject ___Sniper;

        [SerializeField]
        private GameObject ___Launcher;

        [SerializeField]
        private GameObject ___Fighter;

        [SerializeField]
        private GameObject ___Ranger;

        private GameObject UnitObject;

        public IObservable<UnitHitPointMonitor> onCreate {get{return OnCreateSubject;} }
        private Subject<UnitHitPointMonitor> OnCreateSubject= new Subject<UnitHitPointMonitor>();

        public IReactiveCollection<GameObject> unitList { get { return UnitList; } }
        private readonly ReactiveCollection<GameObject> UnitList = new ReactiveCollection<GameObject>();

        public GameObject createUnit(UnitRegistrationInfo unitInfo)
        {
            UnitObject=GetUnit(unitInfo.unitIs);
            OnCreateSubject.OnNext(UnitObject.GetComponent<UnitHitPointMonitor>());
            return UnitObject;
        }

        private GameObject GetUnit(UnitKindIs kind)
        {
            var unit = Instantiate(SelectUnit(kind));
            return unit;

        }
        private GameObject SelectUnit(UnitKindIs kind)
        {
            GameObject unitObj = null;

            switch (kind)
            {
                case UnitKindIs.Nobody:
                    return unitObj;
                case UnitKindIs.NormalUnit:
                    unitObj = ___NormalUnit;
                    return unitObj;
                case UnitKindIs.Dragoon:
                    unitObj = ___Dragoon;
                    return unitObj;
                case UnitKindIs.Ninja:
                    unitObj = ___Ninja;
                    return unitObj;
                case UnitKindIs.Samurai:
                    unitObj = ___Samurai;
                    return unitObj;
                case UnitKindIs.Magi:
                    unitObj = ___Magi;
                    return unitObj;
                case UnitKindIs.Gunman:
                    unitObj = ___Gunman;
                    return unitObj;
                case UnitKindIs.Sniper:
                    unitObj = ___Sniper;
                    return unitObj;
                case UnitKindIs.Launcher:
                    unitObj = ___Launcher;
                    return unitObj;
                case UnitKindIs.Fighter:
                    unitObj = ___Fighter;
                    return unitObj;
                case UnitKindIs.Ranger:
                    unitObj = ___Ranger;
                    return unitObj;
                default:
                    return null;
            }

        }

    }
}