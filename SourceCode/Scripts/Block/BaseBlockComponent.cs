using Assets.Scripts.Unit;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Block
{
    public abstract class BaseBlockComponent : MonoBehaviour
    {
        protected BaseBlock BaseBlock;

        private void Start()
        {
            BaseBlock = GetComponent<BaseBlock>();
            BaseBlock.onInitialize
                .Subscribe(_ =>
                {
                    onInitialize();
                });
        }

        public abstract void onInitialize();

    }
}