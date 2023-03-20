using Assets.Scripts.UI.OrganaizeScene.Mouse;
using Assets.Scripts.UI.OrganaizeScene.SelectUnit;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.Manager {
    public class InitializeShipCorePresenter : MonoBehaviour
    {
        [SerializeField]
        private MouseComponent ___Mouse;
        [SerializeField]
        private BaseShipCoreUI ___BaseShipCoreUI;
        [SerializeField]
        private OrganizeDecision ___Decision;
        [SerializeField]
        private MainManager ___MainManager;

        private void Start()
        {
            ___MainManager.onAsyncInitialize.Subscribe(_=>OnInitialize()).AddTo(this) ;
        }

        private void OnInitialize()
        {

           ___BaseShipCoreUI.onMouseEnter.Subscribe(n =>
           {
               if (n != UnitState.Holded) ___Mouse.State = MouseState.Holdable;
           }).AddTo(this);

           ___BaseShipCoreUI.onMouseExit.Subscribe(_ =>
           {
               ___Mouse.State = MouseState.Normal;
           }).AddTo(this);

           ___BaseShipCoreUI.onMouseDraged.Subscribe(_ =>
           {
               if (___Mouse.State == MouseState.Holdable)
               {
                   ___Mouse.State = MouseState.Hold;
               }

           }).AddTo(this);
            ___Decision.onDecision.Subscribe(_ => ___Decision.addShipCorePos(___BaseShipCoreUI.registerShipCoreInfo(),___BaseShipCoreUI.registerShipCoreInfoOrganize())).AddTo(this);

        }

    }
}