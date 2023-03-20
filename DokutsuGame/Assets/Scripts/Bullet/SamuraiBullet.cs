using Assets.Scripts.Damage;
using Assets.Scripts.CharcterSource;
using UnityEngine;
using System;
using UniRx;

namespace Assets.Scripts.Bullet
{
    public class SamuraiBullet : BaseBullet
    {
        private Transform Tr;

        [SerializeField]
        private SamuraiBulletSummon ___BulletSummon;

        [SerializeField]
        private ___Damage ___BulletDamage;

        private float Zenkinsen = 25;
        private Vector3 d = Vector3.zero;

        private float UnitDirection = 1;

        public IObservable<UniRx.Unit> onSummonBullet { get { return OnSummonBullet; } }
        private Subject<UniRx.Unit> OnSummonBullet = new Subject<UniRx.Unit>();

        // Start is called before the first frame update
        void Start()
        {
            UnitDirection = (transform.localScale.x / Mathf.Abs(transform.localScale.x));
            Tr = GetComponent<Transform>();
            Zenkinsen = Tr.position.x+UnitDirection*Zenkinsen * Mathf.Cos(Tr.eulerAngles.z*Mathf.PI / 180);
            Tr.eulerAngles = Vector3.zero;

        }

        // Update is called once per frame
        void Update()
        {
            d.x =Tr.position.x+bulletVelocityDirection.x * Time.deltaTime;
            if (UnitDirection == 1)
            {
                d.y = Tr.position.y + (-0.05f) / (d.x - Zenkinsen);
            }else if(UnitDirection == -1)
            {
                d.y =Tr.position.y + (0.05f) / (d.x - Zenkinsen);
            }
       
            Tr.position = d;
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

                ___BulletSummon.summonBullet();
                OnSummonBullet.OnNext(UniRx.Unit.Default);
                OnSummonBullet.Dispose();

                Destroy(this.gameObject);

            }
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }

    }


}