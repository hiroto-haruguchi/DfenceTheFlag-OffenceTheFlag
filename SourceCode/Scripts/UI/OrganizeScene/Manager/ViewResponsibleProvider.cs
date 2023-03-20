using Assets.Scripts.UI.OrganaizeScene.SelectUnit;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class ViewResponsibleProvider : MonoBehaviour
    {
        [SerializeField]
        private List<UnitViewer> ___UnitViewerList;
        [SerializeField]
        private List<BlockVIewer> ___BlockViewer;
        [SerializeField]
        private SelectViewerManager ___ViewerManager;
        [SerializeField]
        private MainManager ___MainManager;


        private void Start()
        {
            ___MainManager.onAsyncInitialize.Subscribe(_ => {
                foreach (var it in ___UnitViewerList) {

                    ___ViewerManager.updateResponsibleUnitView
                                  .Subscribe(x => it.setResponsible(x))
                                  .AddTo(this);
                    it.Initialize();
                }

                foreach (var it in ___BlockViewer)
                {
                    ___ViewerManager.updateResponsibleBlockView
                                  .Subscribe(x =>it.setResponsible(x))
                                  .AddTo(this);
                    it.Initialize();
                }

                ___ViewerManager.UpdateUnitViewer(SelectViewerManager.UpdateDirection.Initialize);
                ___ViewerManager.UpdateBlockViewer(SelectViewerManager.UpdateDirection.Initialize);

                foreach (var it in ___BlockViewer) it.setActiveMode(false);

            });



        }

    }
}