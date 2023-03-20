using Assets.Scripts.Damage;
using Assets.Scripts.CharcterSource;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public class MagiBullet : BaseBullet
    {
        private Transform Tr;
        private float VelocityX;
        private float VelocityY;

        private Vector3 BulletAngle=new Vector3(0,0,0);
        private float UnitDirection = 1;

        [SerializeField]
        private ___Damage ___BulletDamage;
        

        // Start is called before the first frame update
        void Start()
        {
            Tr = GetComponent<Transform>();
            UnitDirection = (transform.localScale.x / Mathf.Abs(transform.localScale.x));
            Tr.localScale = new Vector3(Mathf.Abs(Tr.localScale.x * UnitDirection), Mathf.Abs(Tr.localScale.y), Mathf.Abs(Tr.localScale.z));


            VelocityX = Random.Range(UnitDirection*0.01f, UnitDirection*1.0f);
            VelocityY = -0.1f;

            BulletAngle.z = 180 / Mathf.PI * Mathf.Atan2(Mathf.Abs(VelocityY), Mathf.Abs(VelocityX));

            if (UnitDirection == 1)
            {
                transform.eulerAngles = new Vector3(Tr.eulerAngles.x, Tr.eulerAngles.y, Tr.eulerAngles.z - BulletAngle.z);
            }
            else if(UnitDirection == -1)
            {
                transform.eulerAngles = new Vector3(Tr.eulerAngles.x, Tr.eulerAngles.y, 180+ Tr.eulerAngles.z);
                transform.eulerAngles = new Vector3(Tr.eulerAngles.x, Tr.eulerAngles.y, Tr.eulerAngles.z + BulletAngle.z);
            }

   

        }

        // Update is called once per frame
        void Update()
        {
            Tr.position += new Vector3(Time.deltaTime*(VelocityX*10), Time.deltaTime*(VelocityY*10), 0);
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