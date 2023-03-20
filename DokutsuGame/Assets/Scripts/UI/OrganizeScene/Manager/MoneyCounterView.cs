using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class MoneyCounterView : MonoBehaviour
    {
        [SerializeField]
        private Image ___MyImage;

        [SerializeField]
        private NumberViewWarehouse ___Warehouse;

        public IObservable<UniRx.Unit> onAsyncInitialize { get { return OnAsyncInitialize; } }
        private AsyncSubject<UniRx.Unit> OnAsyncInitialize = new AsyncSubject<UniRx.Unit>();

        private void Start()
        {
            OnAsyncInitialize.OnNext(UniRx.Unit.Default);
            OnAsyncInitialize.OnCompleted();
        }

        public void setPlace(int num)
        {
            ___MyImage.sprite = ___Warehouse.getNumberSprite(num);
        }
    }
}