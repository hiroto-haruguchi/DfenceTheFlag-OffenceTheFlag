using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Assets.Scripts.UI.StartScene.StageSelect;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.StartScene.Manager
{
    public class StageSelectButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private Animator ___Animator;
        [SerializeField]
        private StageSelecter ___Selecter;

        public IObservable<UniRx.Unit> onClicked { get { return OnClicked; } }
        private Subject<UniRx.Unit> OnClicked = new Subject<UniRx.Unit>();

        private StageList SelectStage = StageList.Stage1;
        private String CurrentNormalSwitch = "Stage1Normal";
        private string CurrentBrightSwitch = "Stage1Bright";

        void Start()
        {
            ___Selecter.currentStage.Subscribe(x => {

                NormalSwitch(SelectStage, false);
                SelectStage = x;
                NormalSwitch(SelectStage, true);


            }).AddTo(this);
        }

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
            BrightSwitch(SelectStage,true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            BrightSwitch(SelectStage, false);

        }

        private void BrightSwitch(StageList stage,bool value)
        {
            switch (stage)
            {

                case StageList.Stage1:
                    CurrentNormalSwitch = "Stage1Normal";
                    ___Animator.SetBool(CurrentNormalSwitch, value);
                    break;

                case StageList.Stage2:
                    CurrentNormalSwitch = "Stage2Normal";
                    ___Animator.SetBool(CurrentNormalSwitch, value);
                    break;
                case StageList.Stage3:
                    CurrentNormalSwitch = "Stage3Normal";
                    ___Animator.SetBool(CurrentNormalSwitch, value);
                    break;
                case StageList.Stage4:
                    CurrentNormalSwitch = "Stage4Normal";
                    ___Animator.SetBool(CurrentNormalSwitch, value);
                    break;
                case StageList.Stage5:
                    CurrentNormalSwitch = "Stage5Normal";
                    ___Animator.SetBool(CurrentNormalSwitch, value);
                    break;
                case StageList.Stage6:
                    CurrentNormalSwitch = "Stage6Normal";
                    ___Animator.SetBool(CurrentNormalSwitch, value);
                    break;
                default:
                    break;
            }

        }

        private void NormalSwitch(StageList stage,bool value)
        {
            switch (stage)
            {

                case StageList.Stage1:
                    CurrentBrightSwitch = "Stage1Bright";
                    ___Animator.SetBool(CurrentBrightSwitch, value);
                    break;

                case StageList.Stage2:
                    CurrentBrightSwitch = "Stage2Bright";
                    ___Animator.SetBool(CurrentBrightSwitch, value);
                    break;
                case StageList.Stage3:
                    CurrentBrightSwitch = "Stage3Bright";
                    ___Animator.SetBool(CurrentBrightSwitch, value);
                    break;
                case StageList.Stage4:
                    CurrentBrightSwitch = "Stage4Bright";
                    ___Animator.SetBool(CurrentBrightSwitch, value);
                    break;
                case StageList.Stage5:
                    CurrentBrightSwitch = "Stage5Bright";
                    ___Animator.SetBool(CurrentBrightSwitch, value);
                    break;
                case StageList.Stage6:
                    CurrentBrightSwitch = "Stage6Bright";
                    ___Animator.SetBool(CurrentBrightSwitch, value);
                    break;
                default:
                    break;
            }
        }
    }
}