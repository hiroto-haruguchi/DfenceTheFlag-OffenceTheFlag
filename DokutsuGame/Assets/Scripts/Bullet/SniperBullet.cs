using Assets.Scripts.Damage;
using Assets.Scripts.CharcterSource;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class SniperBullet : BaseBullet
    {
        private Transform Tr;
       
        [SerializeField]
        private ___Damage ___BulletDamage;

        
        private Vector2 A = new Vector2(20, 20);
        private Vector2 V = new Vector2(10, 10);


        // Start is called before the first frame update
        void Start()
        {
            Tr = GetComponent<Transform>();

        }

        // Update is called once per frame
        void Update()
        {
            V += A * Time.deltaTime;
            Tr.position += new Vector3(V.x*bulletVelocityDirection.x * Time.deltaTime, V.y*bulletVelocityDirection.y * Time.deltaTime, 0);
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
                ___BulletDamage.value *= 2;

            }
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }

    }


}