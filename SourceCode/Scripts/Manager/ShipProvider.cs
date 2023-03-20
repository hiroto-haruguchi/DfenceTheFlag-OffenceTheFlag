using Assets.Scripts.Damage;
using Assets.Scripts.CharcterSource;
using Assets.Scripts.Ship;
using UnityEngine;
using UniRx;
using System;

namespace Assets.Scripts.Manager
{
    public class ShipProvider : MonoBehaviour
    {
        [SerializeField]
        private GameObject ___BasePrefab;
        [SerializeField]
        private GameObject ___BaseCorePrefab;

        private GameObject BaseObject;
        private GameObject BaseCoreObject;

        public IObservable<ShipCoreHitPointMonitor> onCreateShipCore { get { return OnCreateShipCore; } }
        private AsyncSubject<ShipCoreHitPointMonitor> OnCreateShipCore=new AsyncSubject<ShipCoreHitPointMonitor>();

        public GameObject createShipBase() 
        {
            BaseObject = Instantiate(___BasePrefab);
            return BaseObject;
        }

        public GameObject createShipCore(Vector3 pos)
        {
            BaseCoreObject = Instantiate(___BaseCorePrefab);
            BaseCoreObject.transform.position = pos;
            BaseCoreObject.GetComponent<CharacterBase>().myTag = DogTag.Friend;

            OnCreateShipCore.OnNext(BaseCoreObject.GetComponent<ShipCoreHitPointMonitor>());
            OnCreateShipCore.OnCompleted();

            return BaseCoreObject;
        }
    }
}