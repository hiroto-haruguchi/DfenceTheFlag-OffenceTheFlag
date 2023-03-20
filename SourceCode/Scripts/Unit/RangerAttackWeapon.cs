using Assets.Scripts.Bullet;
using UnityEngine;

namespace Assets.Scripts.Unit
{
    public class RangerAttackWeapon : BaseUnitComponent
    {
        [SerializeField]
        private GameObject ___BulletPrefab;
        [SerializeField]
        private Animator ___Animator;

        private float SecPerAttack;
        private Vector3 BulletPos;

        private float BulletToUnitDistance=1.0f;

        private float DeltaTime = 0;

        //private GameObject BulletObj;
        private BaseBullet BaseBullet;

        private float UnitDirection = 1;

        // Update is called once per frame
        void Update()
        {
            if (IsAttacking == false) DeltaTime += Time.deltaTime;
            if (DeltaTime > SecPerAttack)
            {
               ___Animator.SetBool("Attack", true);
                DeltaTime = 0;
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

            for (float i = 0; i < 1.5f; i += 0.5f)
            {
                var BulletObj = Instantiate(___BulletPrefab);

                BulletPos = Tr.position;
                BaseBullet = BulletObj.GetComponent<BaseBullet>();

                BulletObj.transform.localScale = new Vector3(BulletObj.transform.localScale.x * UnitDirection, BulletObj.transform.localScale.y, BulletObj.transform.localScale.z);

                //Bulletを自分の目の前に配置
                BulletPos.x += BulletToUnitDistance * Mathf.Cos(Core.unitStatus.angle.z * Mathf.PI / 180) * UnitDirection+i;
                BulletPos.y += BulletToUnitDistance * Mathf.Sin(Core.unitStatus.angle.z * Mathf.PI / 180) * UnitDirection;
                BulletObj.transform.position = BulletPos;

                //Bulletが進む方向を決定
                BaseBullet.bulletVelocityDirection.x = Mathf.Cos((Core.unitStatus.angle.z + Random.Range(5, 15)) * Mathf.PI / 180) * UnitDirection;
                BaseBullet.bulletVelocityDirection.y = Mathf.Sin(Core.unitStatus.angle.z * Mathf.PI / 180) * UnitDirection;
                BaseBullet.bulletVelocityDirection *= 5;
                BaseBullet.myTag = Core.myTag;
                BulletObj.transform.eulerAngles = Tr.localEulerAngles;
            }
        }

        private void AttackAnimationEnd()
        {
            ___Animator.SetBool("Attack",false);
            IsAttacking=false;
        }
    }
}