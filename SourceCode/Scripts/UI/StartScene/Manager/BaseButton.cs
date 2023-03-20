using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.StartScene.Manager
{
    public class BaseButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField]
        private Animator ___Animator;

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

        public void OnPointerEnter(PointerEventData eventData)
        {
            ___Animator.SetBool("Bright",true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ___Animator.SetBool("Bright", false);

        }
    }
}