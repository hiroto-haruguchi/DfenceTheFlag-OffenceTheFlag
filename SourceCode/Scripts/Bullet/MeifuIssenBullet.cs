using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Damage;
using Assets.Scripts.Unit;
using Assets.Scripts.CharcterSource;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class MeifuIssenBullet : BaseBullet
    {
        private Transform Tr;
       

        [SerializeField]
        private ___Damage ___BulletDamage;

        [SerializeField]
        private Animator ___Animator;

        // Start is called before the first frame update
        void Start()
        {
            Tr = GetComponent<Transform>();

        }

        // Update is called once per frame
        void Update()
        {
            Tr.position += new Vector3(bulletVelocityDirection.x * Time.deltaTime, bulletVelocityDirection.y * Time.deltaTime, 0);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var hitObjectApplicable = collision.gameObject.GetComponent<IDamageApplicable>();

            if (hitObjectApplicable != null)
            {

                var hitObjectTag = collision.gameObject.GetComponent<CharacterBase>();

                if (hitObjectTag.myTag == this.myTag) return;

                var hitObject = collision.gameObject.GetComponent<IDamageApplicable>();
                hitObject.applyDamage(___BulletDamage);

            }
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }

        private void AnimationEnd()
        {

            ___Animator.SetBool("Attack", false);
            Destroy(this.gameObject);
        }

    }


}