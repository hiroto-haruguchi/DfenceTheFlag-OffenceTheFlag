using Assets.Scripts.UI.OrganaizeScene.Manager;
using Assets.Scripts.UI.StartScene.Manager;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


namespace Assets.Scripts.UI.OrganaizeScene.SelectUnit
{
    public class ButtonViewPresenter : MonoBehaviour
    {
        [SerializeField]
        private List<UnitViewer> ___UnitViewerList;

        [SerializeField]
        private List<BlockVIewer> ___BlockViewerList;

        [SerializeField]
        private BaseButton ___RButton;

        [SerializeField]
        private BaseButton ___LButton;

        [SerializeField]
        private BaseButton ___UnitSelect;

        [SerializeField]
        private BaseButton ___BlockSelect;

        [SerializeField]
        private Assets.Scripts.UI.OrganaizeScene.Manager.MainManager ___MainManager;

        [SerializeField]
        private SelectViewerManager ___ViewerManager;


        // Start is called before the first frame update
        void Start()
        {
            ___MainManager.onAsyncInitialize
                          .Subscribe(_ => Initialized())
                          .AddTo(this);
        }

        private void Initialized()
        {
            //Viewerをアニメーションさせる
            foreach (var it in ___UnitViewerList)
            {
                ___RButton.onClicked.Subscribe(_ =>
                {
                    it.fadeOutRight();
                }).AddTo(this);  

                ___LButton.onClicked.Subscribe(_ =>
                {
                    it.fadeOutLeft();
                 }).AddTo(this);

                ___UnitSelect.onClicked.Subscribe(_ =>
                {
                    it.setActiveMode(true);
                    ___ViewerManager.currentViewer = SelectViewerManager.viewMode.Unit;
                }).AddTo(this);

                ___BlockSelect.onClicked.Subscribe(_ => it.setActiveMode(false)).AddTo(this);    

            }

            //Viewerをアニメーションさせる
            foreach (var it in ___BlockViewerList)
            {
                ___RButton.onClicked.Subscribe(_ => 
                {

                    it.fadeOutRight();
                }).AddTo(this);

                ___LButton.onClicked.Subscribe(_ =>
                {
                    it.fadeOutLeft();
                }).AddTo(this);

                ___UnitSelect.onClicked.Subscribe(_ => it.setActiveMode(false));
                ___BlockSelect.onClicked.Subscribe(_ =>
                {
                    it.setActiveMode(true);
                    ___ViewerManager.currentViewer = SelectViewerManager.viewMode.Block;
                }).AddTo(this);
            }

            //Viewerの担当画像をアップデート
            ___RButton.onClicked.Subscribe(_ =>
            {
                if (___ViewerManager.currentViewer == SelectViewerManager.viewMode.Unit) ___ViewerManager.UpdateUnitViewer(SelectViewerManager.UpdateDirection.Forward);
                else if (___ViewerManager.currentViewer == SelectViewerManager.viewMode.Block) ___ViewerManager.UpdateBlockViewer(SelectViewerManager.UpdateDirection.Forward);
            }).AddTo(this);

            ___LButton.onClicked.Subscribe(_ =>
            {
                if (___ViewerManager.currentViewer == SelectViewerManager.viewMode.Unit) ___ViewerManager.UpdateUnitViewer(SelectViewerManager.UpdateDirection.Backward);
                if (___ViewerManager.currentViewer == SelectViewerManager.viewMode.Block) ___ViewerManager.UpdateBlockViewer(SelectViewerManager.UpdateDirection.Backward);
            }).AddTo(this);
        }
    }
}