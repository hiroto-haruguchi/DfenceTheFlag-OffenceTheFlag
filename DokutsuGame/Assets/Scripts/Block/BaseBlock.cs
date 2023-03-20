using System;
using Assets.Scripts.CharcterSource;
using Assets.Scripts.Damage;
using Assets.Scripts.Manager;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Block
{
    public class BaseBlock : CharacterBase, IDamageApplicable
    {


        public int blockHitPoint;
        public BlockKindIs blockKind;

        private BlockRegistrationInfo BlockInfo;
        public IObservable<UniRx.Unit> onInitialize { get { return OnInitializeAsyncSubject; } }
        private AsyncSubject<UniRx.Unit> OnInitializeAsyncSubject = new AsyncSubject<UniRx.Unit>();

        public IObservable<___Damage> onDamaged { get { return OnDamaged; } }
        private Subject<___Damage> OnDamaged = new Subject<___Damage>();

        public void initializeBlock(BlockRegistrationInfo info)
        {
            BlockInfo = info;
            myTag = info.myTag;
            var tr = GetComponent<Transform>();
            tr.position = info.pos;
            OnInitializeAsyncSubject.OnNext(UniRx.Unit.Default);
            OnInitializeAsyncSubject.OnCompleted();

        }

        public void applyDamage(___Damage damage)
        {
            OnDamaged.OnNext(damage);
        }
        private void DamageAnimationEnd()
        {
        }
        public void destroy()
        {
            Destroy(this.gameObject);
        }


    }
}