using UnityEngine;
using Assets.Scripts.Ship;

namespace Assets.Scripts.UI.BattleScene.Ship {

    public class ShipCoreHitPointDsipatcherEnemy : MonoBehaviour
    {
        [SerializeField]
        private ShipCoreHitPointMonitor ___HitPointMonitor;

        [SerializeField]
        private GameObject ___View;

        [SerializeField]
        private ShipCoreHitPointPresenter ___Presenter;

        private void Start()
        {
            Dispatch(___HitPointMonitor);
        }

        private void Dispatch(ShipCoreHitPointMonitor core)
        {
            ___Presenter.onCreateShipCore(core,___View.GetComponent<ShipCoreHItPointView>());

        }
    }
}