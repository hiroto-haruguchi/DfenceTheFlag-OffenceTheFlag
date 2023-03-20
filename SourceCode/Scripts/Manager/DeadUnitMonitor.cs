using Assets.Scripts.Unit;
using UniRx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Manager {
    public class DeadUnitMonitor : MonoBehaviour
    {
        private const int UNITNUM = 0;
        private int UnitNum;
        private UnitProvider UnitProvider;

        void Strat()
        {
            UnitNum = UNITNUM;
            UnitProvider=GetComponent<UnitProvider>();

            UnitProvider.onCreate.Subscribe(x =>
            {
                UnitNum++;
                registerUnit(x);

            });
;
        }

        public void registerUnit(UnitHitPointMonitor unitHitPointMonitor) {

            unitHitPointMonitor.onDead
                .Subscribe(_ =>UnitNum--)
                .AddTo(this);
        
        }
    }
}