using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Block
{
    public class BlockHitPointManager : BaseBlockComponent
    {
        [SerializeField]
        private Animator ___Animator;

        private float hp = 0.0f;

        public override void onInitialize()
        {
            hp = BaseBlock.blockHitPoint;
            BaseBlock.onDamaged
                .Subscribe(x =>
                {
                    //HPå∏è≠èàóù
                    hp -= x.value;

                    if (hp <= 0)BaseBlock.destroy();
                    else if (hp < (BaseBlock.blockHitPoint / 4)) ___Animator.SetBool("Quarter", true);
                    else if (hp < (BaseBlock.blockHitPoint / 2)) ___Animator.SetBool("Harf", true);
                }
                 ).AddTo(this);

        }

    }


}