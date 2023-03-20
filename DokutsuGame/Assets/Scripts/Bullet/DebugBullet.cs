using Assets.Scripts.Damage;
using Assets.Scripts.CharcterSource;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class DebugBullet : BaseBullet
    {
        private Transform tr;
       

        [SerializeField]
        private ___Damage ___BulletDamage;
        

        // Start is called before the first frame update
        void Start()
        {
            tr = GetComponent<Transform>();

        }

        // Update is called once per frame
        void Update()
        {
            tr.position += new Vector3(bulletVelocityDirection.x * Time.deltaTime, bulletVelocityDirection.y * Time.deltaTime, 0);
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
        }

    }


}