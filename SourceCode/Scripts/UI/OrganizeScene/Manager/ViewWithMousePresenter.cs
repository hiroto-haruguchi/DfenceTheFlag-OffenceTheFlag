using System.Collections.Generic;
using Assets.Scripts.UI.OrganaizeScene.Mangaer;
using Assets.Scripts.UI.OrganaizeScene.Mouse;
using Assets.Scripts.UI.OrganaizeScene.SelectUnit;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class ViewWithMousePresenter : MonoBehaviour
    {
        [SerializeField]
        private List<UnitViewer> ___UnitViewerList;

        [SerializeField]
        private List<BlockVIewer> ___BlockViewerList;

        [SerializeField]
        private OverViewChanger ___OverViewChanger;

        [SerializeField]
        private MouseComponent ___Mouse;
        [SerializeField]
        private MainManager ___MainManager;
        [SerializeField]
        private UnitProviderUI ___UnitProvider;
        [SerializeField]
        private BlockProviderUI ___BlockProvider;


        private void Start()
        {
            ___MainManager.onAsyncInitialize
                          .Subscribe(_ => OnInitialize())
                          .AddTo(this);
        }

        private void OnInitialize()
        {
            foreach (var it in ___UnitViewerList)
            {
                it.onMouseEnter.Subscribe(x =>
                {
                    ___Mouse.setCreateUnit(x);
                    ___OverViewChanger.changeOverView(it.getIam());
                }).AddTo(this);

                it.onMouseExit.Subscribe(_ =>
                {
                    ___Mouse.removeCreateUnit();
                }).AddTo(this);

                it.onMouseDraged.Subscribe(_ =>
                {
                    ___Mouse.unitCreate();

                }).AddTo(this);
            }

            foreach (var it in ___BlockViewerList)
            {
                it.onMouseEnter.Subscribe(x =>
                {
                    ___Mouse.setCreateBlock(x);
                    ___OverViewChanger.changeOverView(it.getIam());
                }).AddTo(this);

                it.onMouseExit.Subscribe(_ =>
                {
                    ___Mouse.removeCreateBlock();
                }).AddTo(this);

                it.onMouseDraged.Subscribe(_ =>
                {
                    ___Mouse.blockCreate();

                }).AddTo(this);
            }

        }
    }
    
}