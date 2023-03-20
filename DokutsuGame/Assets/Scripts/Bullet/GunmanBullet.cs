using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Damage;
using Assets.Scripts.Unit;
using Assets.Scripts.CharcterSource;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class GunmanBullet : BaseBullet
    {
        private Transform Tr;
        private float AdditionalGunmanBulletVelocity = 10;
        


        [SerializeField]
        private ___Damage ___BulletDamage;
        

        // Start is called before the first frame update
        void Start()
        {
            Tr = GetComponent<Transform>();

        }

        // Update is called once per frame
        void Update()
        {
            Tr.position += new Vector3(Mathf.Cos(transform.localEulerAngles.z * Mathf.Deg2Rad )* bulletVelocityDirection.x * Time.deltaTime* AdditionalGunmanBulletVelocity, 
                                       Mathf.Sin(transform.localEulerAngles.z * Mathf.Deg2Rad )* bulletVelocityDirection.y * Time.deltaTime* AdditionalGunmanBulletVelocity,
                                       0);
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