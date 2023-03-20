using UnityEngine;
using System;
using UniRx;

namespace Assets.Scripts.Bullet
{
    public class SamuraiBulletSummon : BaseBullet
    {
        [SerializeField]
        private GameObject ___BulletPrefab;

        [SerializeField]
        private Animator ___Animator;

        private Vector3 BulletPos;
        private Transform Tr;

        private float UnitDirection = 1;

        public IObservable<UniRx.Unit> onSummonBulletsEnd { get { return OnSummonBulletsEnd; } }
        private Subject<UniRx.Unit> OnSummonBulletsEnd = new Subject<UniRx.Unit>();

        private void Start()
        {
            Tr = this.transform;
            UnitDirection = (transform.localScale.x / Mathf.Abs(transform.localScale.x));
        }

        private void AnimationEnd()
        {
            Destroy(this.gameObject);
        }

        public void summonBullet()
        {

            var BulletObj = Instantiate(___BulletPrefab);
            BulletObj.transform.localScale = new Vector3(BulletObj.transform.localScale.x * UnitDirection, BulletObj.transform.localScale.y, BulletObj.transform.localScale.z);

            BulletPos = Tr.position;
            var BaseBullet = BulletObj.GetComponent<BaseBullet>();

            BulletPos.x = 0;
            BulletObj.transform.position = BulletPos;
            BaseBullet.myTag = this.myTag;
            
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }

    }


}