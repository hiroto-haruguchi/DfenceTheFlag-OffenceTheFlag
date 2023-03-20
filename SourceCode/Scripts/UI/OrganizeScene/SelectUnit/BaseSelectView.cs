using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.OrganaizeScene.SelectUnit
{
    public class BaseSelectView : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {

        public IObservable<UniRx.Unit> onClicked { get { return OnClicked; } }
        private Subject<UniRx.Unit> OnClicked = new Subject<UniRx.Unit>();

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked.OnNext(UniRx.Unit.Default);
        }

        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnPointerUp(PointerEventData eventData)
        {

        }
    }
}