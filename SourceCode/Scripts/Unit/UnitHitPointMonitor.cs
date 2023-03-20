using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public class UnitHitPointMonitor : BaseUnitComponent
    {
        public float hp = 0.0f;

        public IObservable<UniRx.Unit> onDead { get { return OnDeadSubject; } }
        private Subject<UniRx.Unit> OnDeadSubject=new Subject<UniRx.Unit>();

        public override void onInitialize()
        {

            Core.onDamaged
                .Subscribe(x=>
                 {
                   hp-=x.value;
                     if (hp <= 0)
                     {
                        OnDeadSubject.OnNext(UniRx.Unit.Default);
                        Core.Destroy();
                      }
                 }
                 )
                 .AddTo(this);

        }


    }
}