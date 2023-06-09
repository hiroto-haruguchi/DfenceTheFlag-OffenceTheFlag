using UniRx;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    public class ShipCoreHitPointMonitor : MonoBehaviour
    {
        public float MaxHealth;
        public IReadOnlyReactiveProperty<float> shipCoreHitPoint { get { return ShipCoreHitPoint; } }
        private readonly FloatReactiveProperty ShipCoreHitPoint = new FloatReactiveProperty();
        
        public void initializeHitPointMonitor(ShipCore shipCore)
        {
            MaxHealth = shipCore.___coreHitPoint;
            ShipCoreHitPoint.Value=shipCore.___coreHitPoint;

            //ShipCoreの当たり判定を貰う
            shipCore.onDamaged
                .Subscribe(x=>
                {
                    ShipCoreHitPoint.Value -= x.value;
                }).AddTo(this);

        }

        private void OnDestroy()
        {
            ShipCoreHitPoint.Dispose();

        }
    }


}