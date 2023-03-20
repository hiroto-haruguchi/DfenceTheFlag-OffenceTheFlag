using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Damage;
using Assets.Scripts.Unit;
using Assets.Scripts.CharcterSource;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class FighterBullet : BaseBullet
    {
        private Transform Tr;
        private Rigidbody2D Rb;
        private Vector3 A;
        private Vector3 BulletAngle=new Vector3(0,0,0);


        [SerializeField]
        private ___Damage ___BulletDamage;
        

        // Start is called before the first frame update
        void Start()
        {
            A = new Vector3(Mathf.Cos(transform.localEulerAngles.z*Mathf.Deg2Rad)*5,Mathf.Sin(transform.localEulerAngles.z * Mathf.Deg2Rad)*10,0);
            Tr = GetComponent<Transform>();
            Rb = GetComponent<Rigidbody2D>();
            Rb.AddForce(A,ForceMode2D.Impulse);

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
                Destroy(this.gameObject);

            }
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
    }


}