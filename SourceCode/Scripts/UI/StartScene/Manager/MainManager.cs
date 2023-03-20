using Assets.Scripts.UI.StartScene.StageSelect;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.StartScene.Manager
{
    public class MainManager : MonoBehaviour
    {
        [SerializeField]
        private MenuViewManager ___MenuViewManager;
        [SerializeField]
        private BackMenuView ___BackMenu;


        public IObservable<UniRx.Unit> onInitialize { get { return OnInitializeAsyncSubject; } }
        private AsyncSubject<UniRx.Unit> OnInitializeAsyncSubject = new AsyncSubject<UniRx.Unit>();

        private ReactiveProperty<SelectMode> CurrentSelectMode = new ReactiveProperty<SelectMode>(SelectMode.Start);

        
        

        // Start is called before the first frame update
        void Start()
        {

            Time.timeScale = 1.0f;
            CurrentSelectMode.Subscribe(n => setMenuView(n));
            OnInitializeAsyncSubject.OnNext(UniRx.Unit.Default);
            OnInitializeAsyncSubject.OnCompleted();
        }

        private void setMenuView(SelectMode MenuMode)
        {
            switch (MenuMode)
            {
                case SelectMode.Start:
                    ___MenuViewManager.setStartMode();
                    break;
                case SelectMode.StageSelect:
                    ___BackMenu.setPreviousSelectMode(SelectMode.Start);
                    ___MenuViewManager.setStageSelectMode();
                    break;
                case SelectMode.GameExit:
                    Application.Quit();
                    break;
                default:
                    break;
            }

            
        }

        public void setCurrentSelectMode(SelectMode mode) { CurrentSelectMode.Value = mode; }
        public SelectMode getCurrnetSelectMode() { return CurrentSelectMode.Value; }
    }
}