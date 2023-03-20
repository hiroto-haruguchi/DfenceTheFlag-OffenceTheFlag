using Assets.Scripts.Manager;
using Assets.Scripts.UI.OrganaizeScene.Manager;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.OrganaizeScene.SelectUnit
{
    public class BlockVIewer : BaseViewer, IPointerEnterHandler, IPointerExitHandler, IDragHandler
    {

        [SerializeField]
        private Image ___MyImage;

        [SerializeField]
        private SourceImageWarehouse ___Warehouse;

        private ReactiveProperty<BlockKindIs> Iam = new ReactiveProperty<BlockKindIs>(BlockKindIs.Nobody);

        public IObservable<BlockKindIs> onMouseEnter { get { return OnMouseEnter; } }
        private Subject<BlockKindIs> OnMouseEnter = new Subject<BlockKindIs>();

        public IObservable<UniRx.Unit> onMouseExit { get { return OnMouseExit; } }
        private Subject<UniRx.Unit> OnMouseExit = new Subject<UniRx.Unit>();

        public IObservable<UniRx.Unit> onMouseDraged { get { return OnMouseDraged; } }
        private Subject<UniRx.Unit> OnMouseDraged = new Subject<UniRx.Unit>();

        public void Initialize()
        {
            Iam.SkipLatestValueOnSubscribe()
               .Subscribe(x => {
                    ___MyImage.sprite = ___Warehouse.setBlockSourceImageSprite(x);
               }).AddTo(this);
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

        public void setResponsible(BlockKindIs[] myResponsible)
        {
            Iam.Value = myResponsible[this.Responsible];
        }
        public BlockKindIs getIam()
        {
            return Iam.Value;
        }
    }
}