using Assets.Scripts.UI.StartScene.Manager;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.StartScene.StageSelect
{
    public class StageSelectWithButtonPresenter : MonoBehaviour
    {
        [SerializeField]
        private MainManager ___Manager;
        [SerializeField]
        private BaseButton ___RightButton;
        [SerializeField]
        private BaseButton ___LeftButton;
        [SerializeField]
        private StageSelecter ___StageSelecter;
        [SerializeField]
        private BaseButton ___StageSelectButton;


        // Start is called before the first frame update
        void Start()
        {
            ___Manager.onInitialize.Subscribe(_ => Initialize()).AddTo(this);
        }

        private void Initialize()
        {
            ___RightButton.onClicked.Subscribe(_ => ___StageSelecter.changeStageList(StageSelecter.listDirection.Forward)).AddTo(this);
            ___LeftButton.onClicked.Subscribe(_ => ___StageSelecter.changeStageList(StageSelecter.listDirection.Backward)).AddTo(this);
            ___StageSelectButton.onClicked.Subscribe(__ =>
            {
                var _=___StageSelecter.sceneLoad();
            }).AddTo(this);

        }
    }
}