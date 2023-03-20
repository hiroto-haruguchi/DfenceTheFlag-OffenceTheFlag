using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class MoneyCounter : MonoBehaviour
    {
        [SerializeField]
        private MainManager ___MainManager;
        [SerializeField]
        private MoneyCounterView ___MoneyCounterView;
        [SerializeField]
        private MoneyCounterView ___OnesPlace;
        [SerializeField]
        private MoneyCounterView ___TensPlace;
        [SerializeField]
        private MoneyCounterView ___HundredsPlace;

        private IntReactiveProperty Money = new IntReactiveProperty(100);

        public IObservable<UniRx.Unit> onAsyncInitialize { get{ return OnAsyncInitialize; } }
        private AsyncSubject<UniRx.Unit> OnAsyncInitialize = new AsyncSubject<UniRx.Unit>();

        // Start is called before the first frame update
        void Start()
        {
            Money.Subscribe(x => {
                ___OnesPlace.setPlace(x % 10);
                ___TensPlace.setPlace((x/10) % 10);
                ___HundredsPlace.setPlace(x / 100);

            }).AddTo(this);
            ___MainManager.onAsyncInitialize.Subscribe(x => {

                Money.Value = x.progress.getMoney();
                OnAsyncInitialize.OnNext(UniRx.Unit.Default);
                OnAsyncInitialize.OnCompleted();
            }).AddTo(this);


        }

        public void  setMoney(int value)
        {
            Money.Value += value;
        }

        public bool canBuy(int value)
        {
            if (Money.Value - value < 0) return false;
            else return true;
        }
    }

}