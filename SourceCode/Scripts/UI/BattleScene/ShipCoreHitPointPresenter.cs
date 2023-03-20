using Assets.Scripts.Ship;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.BattleScene.Ship {
    public class ShipCoreHitPointPresenter : MonoBehaviour
    {
        public void onCreateShipCore(ShipCoreHitPointMonitor hpMonitor, ShipCoreHItPointView shipCoreView) {

            hpMonitor.shipCoreHitPoint
                .SkipLatestValueOnSubscribe()
                .Subscribe(x =>
                {
                    shipCoreView.setHealth(x/hpMonitor.MaxHealth);
                }).AddTo(this);

        }
    }
}