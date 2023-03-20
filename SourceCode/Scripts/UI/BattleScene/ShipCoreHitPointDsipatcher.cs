using UnityEngine;
using Assets.Scripts.Manager;
using Assets.Scripts.Ship;
using UniRx;

namespace Assets.Scripts.UI.BattleScene.Ship {

    public class ShipCoreHitPointDsipatcher : MonoBehaviour
    {
        [SerializeField]
        private ShipProvider ___Provider;

        [SerializeField]
        private GameObject ___View;

        [SerializeField]
        private ShipCoreHitPointPresenter ___Presenter;

        private void Start()
        {
            ___Provider.onCreateShipCore.Subscribe(x => Dispatch(x)).AddTo(this);

        }

        private void Dispatch(ShipCoreHitPointMonitor core)
        {
            ___Presenter.onCreateShipCore(core,___View.GetComponent<ShipCoreHItPointView>());

        }
    }
}