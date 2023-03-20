using System;
using Assets.Scripts.Damage;
using Assets.Scripts.CharcterSource;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class ShipCore : CharacterBase, IDamageApplicable
    {

        [SerializeField]
        public float ___coreHitPoint;
        [SerializeField]
        private Animator ___Animator;
        public IObservable<___Damage> onDamaged { get { return OnDamaged; } }
        private Subject<___Damage> OnDamaged = new Subject<___Damage>();

        private ShipCoreHitPointMonitor ShipCoreHitPointMonitor;

        public void initializeShipCore(Vector3 shipCorePos,DogTag tag)
        {
            ShipCoreHitPointMonitor=GetComponent<ShipCoreHitPointMonitor>();
            ShipCoreHitPointMonitor.initializeHitPointMonitor(this);
            transform.position = shipCorePos;
            myTag = tag;

        }

        public void  applyDamage(___Damage Damage){

            OnDamaged.OnNext(Damage);
            ___Animator.SetBool("Damage", true);
        }

        private void DamageAnimationEnd()
        {
            ___Animator.SetBool("Damage", false);
        }

        public void OnDestroy()
        {
            OnDamaged.Dispose();
        }
    }
}