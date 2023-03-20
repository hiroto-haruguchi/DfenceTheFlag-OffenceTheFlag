using UniRx;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public abstract class BaseUnitComponent : MonoBehaviour
    {
        protected UnitCore Core;
        protected Transform Tr;
        protected bool IsAttacking = false;

        private void Start()
        {
            Core = GetComponent<UnitCore>();
            Tr= GetComponent<Transform>();
            
            Core.onInitialize
                .Subscribe(_ => 
                {
                    onInitialize();
                }).AddTo(this);
        }

        public abstract void onInitialize();

    }


}