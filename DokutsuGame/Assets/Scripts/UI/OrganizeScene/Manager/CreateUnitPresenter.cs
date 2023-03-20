using Assets.Scripts.UI.OrganaizeScene.Mouse;
using Assets.Scripts.UI.OrganaizeScene.SelectUnit;
using UniRx;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class CreateUnitPresenter : MonoBehaviour
    {
        [SerializeField]
        private UnitProviderUI ___UnitProvider;
        [SerializeField]
        private BlockProviderUI ___BlockProvider;
        [SerializeField]
        private OrganizeDecision ___Dicision;
        [SerializeField]
        private MainManager ___Manager;
        [SerializeField]
        private MouseComponent ___Mouse;

        public async UniTask onInitializeAsync()
        {
            //ì‚Á‚½UnitUI‚ÆMouseComponent‚ð‰Šú‰»
            ___UnitProvider.unitList.ObserveAdd()
                    .Subscribe(x =>
                    {
                        var unitUI=x.Value.GetComponent<BaseUnitUI>();
                        unitUI.onMouseEnter.Subscribe(n =>
                        {
                            if(n!=UnitState.Holded) ___Mouse.State = MouseState.Holdable;
                        }).AddTo(x.Value);

                        unitUI.onMouseExit.Subscribe(_ =>
                        {
                            ___Mouse.State = MouseState.Normal;
                        }).AddTo(x.Value);

                        unitUI.onMouseDraged.Subscribe(_ =>
                        {
                            if (___Mouse.State == MouseState.Holdable)
                            {
                                ___Mouse.State = MouseState.Hold;
                            }

                        }).AddTo(x.Value);

                        ___Dicision.onDecision.Subscribe(_ =>
                        {
                            ___Dicision.addUnitsList(unitUI.registerUnitInfo(),unitUI.registerUnitInfoOrganize());
                        }).AddTo(x.Value);

                    }).AddTo(this);

            ___BlockProvider.blockList.ObserveAdd()
                    .Subscribe(x =>
                    {
                        var blockUI=x.Value.GetComponent<BaseBlockUI>();
                        blockUI.onMouseEnter.Subscribe(n =>
                        {
                            if (n != UnitState.Holded) ___Mouse.State = MouseState.Holdable;
                        }).AddTo(x.Value);

                        blockUI.onMouseExit.Subscribe(_ =>
                        {
                            ___Mouse.State = MouseState.Normal;
                        }).AddTo(x.Value);

                        blockUI.onMouseDraged.Subscribe(_ =>
                        {
                            if (___Mouse.State == MouseState.Holdable)
                            {
                                ___Mouse.State = MouseState.Hold;
                            }

                        }).AddTo(x.Value);
                        ___Dicision.onDecision.Subscribe(_ =>
                        {
                            ___Dicision.addBlockList(blockUI.registerBlockInfo(),blockUI.registerBlockInfoOrganize());
                        }).AddTo(x.Value);
                    }).AddTo(this);

        }
    }
}