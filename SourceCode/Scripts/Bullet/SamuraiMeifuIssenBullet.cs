using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Damage;
using Assets.Scripts.Unit;
using Assets.Scripts.CharcterSource;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class SamuraiMeifuIssenBullet : BaseBullet
    {
        private Transform Tr;
       

        [SerializeField]
        private ___Damage ___BulletDamage;

        [SerializeField]
        private Animator ___Animator;

        [SerializeField]
        private GameObject ___MeifuIssenBullet;
        
        private bool IsIaiAttacking=false;

        private float Velocity = 200;

        private Vector3 BulletPos;

        private float UnitDirection = 1;

        // Start is called before the first frame update
        void Start()
        {
            Tr = GetComponent<Transform>();
            UnitDirection = (transform.localScale.x / Mathf.Abs(transform.localScale.x));

        }

        // Update is called once per frame
        void Update()
        {
            if(IsIaiAttacking == true ) Tr.position += new Vector3(UnitDirection*Velocity* Time.deltaTime, 0, 0);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var hitObjectApplicable = collision.gameObject.GetComponent<IDamageApplicable>();

            if(hitObjectApplicable != null)
            {

                var hitObjectTag = collision.gameObject.GetComponent<CharacterBase>();

                if (hitObjectTag.myTag == this.myTag) return;

                var hitObject = collision.gameObject.GetComponent<IDamageApplicable>();
                hitObject.applyDamage(___BulletDamage);
                Destroy(this.gameObject);

            }
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
            var BulletObj = Instantiate(___MeifuIssenBullet);
            var BaseBullet = BulletObj.GetComponent<BaseBullet>();
            BulletObj.transform.localScale = new Vector3(BulletObj.transform.localScale.x * UnitDirection, BulletObj.transform.localScale.y, BulletObj.transform.localScale.z);
            BulletPos = Tr.position;

            BulletPos.x = 0;
            BulletObj.transform.position = BulletPos;
            BaseBullet.myTag = this.myTag;
        }

        private void AnimationAttackEnd()
        {
            ___Animator.SetBool("Wait", true);

        }

        private void AnimationWaitEnd()
        {
            ___Animator.SetBool("Attack", true);
            IaiMove();

        }

        private void IaiMove()
        {
            IsIaiAttacking = true;
        }

    }


}