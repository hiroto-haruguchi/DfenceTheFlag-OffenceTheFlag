using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Damage;
using Assets.Scripts.Unit;
using Assets.Scripts.CharcterSource;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class NinjaBullet : BaseBullet,IDamageApplicable
    {
        [SerializeField]
        private ___Damage ___BulletDamage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var hitObjectApplicable = collision.gameObject.GetComponent<IDamageApplicable>();

            if (hitObjectApplicable != null)
            {

                var hitObjectTag = collision.gameObject.GetComponent<CharacterBase>();

                if (hitObjectTag.myTag == this.myTag) return;

                var hitObject = collision.gameObject.GetComponent<IDamageApplicable>();
                hitObject.applyDamage(___BulletDamage);
                Destroy(this.gameObject);

            }
        }

        private void AnimationEnd()
        {
            Destroy(this.gameObject);
        
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }

        public void applyDamage(___Damage damage)
        {

        }

    }


}