using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Damage;
using Assets.Scripts.Unit;
using Assets.Scripts.CharcterSource;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class RocketmanBullet : BaseBullet
    {
        private Transform Tr;
       

        [SerializeField]
        private ___Damage ___BulletDamage;

        [SerializeField]
        private Animator ___Animator;

        private bool IsExploding = false;

        private Vector2 a =  new Vector2(10,10);
        private Vector2 v = new Vector2(1,1);

        // Start is called before the first frame update
        void Start()
        {
            Tr = GetComponent<Transform>();

        }

        // Update is called once per frame
        void Update()
        {
            v += a * Time.deltaTime;
            if(IsExploding!=true) Tr.position += new Vector3(v.x*bulletVelocityDirection.x * Time.deltaTime, v.y*bulletVelocityDirection.y * Time.deltaTime, 0);
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

                ___Animator.SetBool("Explosion", true);
                IsExploding = true;
            }
        }

        private void AnimationDestroy()
        {
            Destroy(this.gameObject);
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }

    }


}