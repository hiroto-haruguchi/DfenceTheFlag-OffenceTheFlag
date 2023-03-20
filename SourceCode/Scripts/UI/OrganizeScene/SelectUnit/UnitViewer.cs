using System;
using Assets.Scripts.Manager;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Scripts.UI.OrganaizeScene.Manager;
using Assets.Scripts.Save;

namespace Assets.Scripts.UI.OrganaizeScene.SelectUnit
{
    public class UnitViewer : BaseViewer,IPointerEnterHandler,IPointerExitHandler,IDragHandler
    {
        [SerializeField]
        private Image ___MyImage;

        [SerializeField]
        private SourceImageWarehouse ___Warehouse;

        [SerializeField]
        private MainManager ___MainManager;

        private UnitProgressList ___ProgressList = new UnitProgressList();

        private ManagementData Progress;

        private ReactiveProperty<UnitKindIs> Iam= new ReactiveProperty<UnitKindIs>(UnitKindIs.NormalUnit);

        public IObservable<UnitKindIs> onMouseEnter { get { return OnMouseEnter; } }
        private Subject<UnitKindIs> OnMouseEnter = new Subject<UnitKindIs>();

        public IObservable<UniRx.Unit> onMouseExit { get { return OnMouseExit; } }
        private Subject<UniRx.Unit> OnMouseExit=new Subject<UniRx.Unit>();

        public IObservable<UniRx.Unit> onMouseDraged { get { return OnMouseDraged; } }
        private Subject<UniRx.Unit> OnMouseDraged = new Subject<UniRx.Unit>();

        public void Initialize()
        {
            Iam.Subscribe(x => {
                    ___MyImage.sprite = ___Warehouse.setUnitSourceImageSprite(x);
               }).AddTo(this);
            ___MainManager.onAsyncInitialize.Subscribe(x => Progress = x.progress);
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            OnMouseEnter.OnNext(Iam.Value);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            OnMouseExit.OnNext(UniRx.Unit.Default);

        }

        public void OnDrag(PointerEventData eventData)
        {
            OnMouseDraged.OnNext(UniRx.Unit.Default);

        }

        public void setResponsible(UnitKindIs[] myResponsible)
        {
            if (Progress.getData(___ProgressList.getListData(myResponsible[this.Responsible])) == false) Iam.Value = UnitKindIs.Nobody;
            else Iam.Value = myResponsible[this.Responsible];
        }

        public UnitKindIs getIam()
        {
            return Iam.Value;
        }
    }
}