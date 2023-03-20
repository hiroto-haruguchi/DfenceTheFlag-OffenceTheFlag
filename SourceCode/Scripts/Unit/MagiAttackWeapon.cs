using System.Collections;
using System.Collections.Generic;
using UniRx;
using Assets.Scripts.Bullet;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public class MagiAttackWeapon : BaseUnitComponent
    {
        [SerializeField]
        private GameObject ___SummonBulletPrefab;
        [SerializeField]
        private Animator ___Animator;

        private float SecPerAttack;
        private Vector3 BulletPos;

        private float DeltaTime = 0;

        private GameObject BulletObj;
        private BaseBullet BaseBullet;

        private float UnitDirection = 1;

        // Update is called once per frame
        void Update()
        {
            if (IsAttacking == false) DeltaTime += Time.deltaTime;

            if (DeltaTime > SecPerAttack)
            {
                DeltaTime = 0;
                ___Animator.SetBool("Attack", true);

            }
        }

        public override void onInitialize()
        {
            SecPerAttack = Core.___parameter.SecPerAttack;
            UnitDirection = (transform.localScale.x / Mathf.Abs(transform.localScale.x));

        }

        private void Attack()
        {
            IsAttacking = true;

            BulletObj = Instantiate(___SummonBulletPrefab);

            BulletObj.GetComponent<MagiBulletSummon>().onSummonBulletsEnd.Subscribe(_ => IsAttacking = false);
            BulletObj.transform.localScale = new Vector3(BulletObj.transform.localScale.x * UnitDirection, BulletObj.transform.localScale.y, BulletObj.transform.localScale.z);

            BulletPos = Tr.position;
            BaseBullet = BulletObj.GetComponent<BaseBullet>();

            //Bullet‚ðŽ©•ª‚Ì–Ú‚Ì‘O‚É”z’u
            BulletPos.y += 10;
            BulletObj.transform.position = BulletPos;
            BaseBullet.myTag = Core.myTag;
        }

        private void AttackAnimationEnd()
        {

            ___Animator.SetBool("Attack",false);
        }
    }
}