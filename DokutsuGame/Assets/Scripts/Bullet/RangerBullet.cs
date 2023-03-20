using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Damage;
using Assets.Scripts.Unit;
using Assets.Scripts.CharcterSource;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class RangerBullet : BaseBullet
    {
        private Transform Tr;
        private Rigidbody2D Rb;
        private Vector3 A;
        private Vector3 BulletAngle;

        private float BulletARatioX = 5.0f;
        private float BulletARatioY = 10.0f;

        [SerializeField]
        private ___Damage ___BulletDamage;
        private float UnitDirection = 1;

        // Start is called before the first frame update
        void Start()
        {
            UnitDirection = (transform.localScale.x / Mathf.Abs(transform.localScale.x));

            if (UnitDirection == 1)
            {
                A = new Vector3(UnitDirection * Mathf.Cos(transform.localEulerAngles.z * Mathf.Deg2Rad) * BulletARatioX, Mathf.Sin(transform.localEulerAngles.z * Mathf.Deg2Rad) * BulletARatioY, 0);
            }else if(UnitDirection == -1)
            {
                A = new Vector3(UnitDirection * Mathf.Cos((360-transform.localEulerAngles.z) * Mathf.Deg2Rad) * BulletARatioX, Mathf.Sin((360-transform.localEulerAngles.z) * Mathf.Deg2Rad) * BulletARatioY, 0);
            }
            Tr = GetComponent<Transform>();
            Rb = GetComponent<Rigidbody2D>();
            Rb.AddForce(A,ForceMode2D.Impulse);

        }

        // Update is called once per frame
        void Update()
        {
            BulletAngle = Tr.eulerAngles;
            if (UnitDirection == 1)
            {
                BulletAngle.z = 180 / Mathf.PI * Mathf.Atan2(Rb.velocity.y, Rb.velocity.x);
            }
            else if (UnitDirection == -1)
            {
                BulletAngle.z = 180 + 180 / Mathf.PI * Mathf.Atan2(Rb.velocity.y, Rb.velocity.x);
            }

            Tr.eulerAngles = BulletAngle;

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
                Destroy(this.gameObject);

            }
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
    }


}