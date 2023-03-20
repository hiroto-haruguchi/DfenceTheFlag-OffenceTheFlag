using UnityEngine;

namespace Assets.Scripts.Ship
{

    public class ShipMover : MonoBehaviour
    {
        private Transform Tr;
        private Rigidbody2D Rb;

        [SerializeField]
        private Transform ___FrontSyarin;
        [SerializeField]
        private Transform ___EndSyarin;

        private Vector3 ShipVelocity= new Vector3(1,0,0);
        private Vector3 ShipDirection = new Vector3(1,0,0);
        private float AngularVelocity = 20;


        private float DeltaTime = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            Tr=GetComponent<Transform>();
            Rb=GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            DeltaTime=Time.deltaTime;
            Tr.position += new Vector3(ShipVelocity.x*ShipDirection.x*DeltaTime,ShipVelocity.y*ShipDirection.y*DeltaTime,0);
            ___FrontSyarin.eulerAngles = new Vector3(___FrontSyarin.eulerAngles.x, ___FrontSyarin.eulerAngles.y, ___FrontSyarin.eulerAngles.z - AngularVelocity * ShipDirection.x * DeltaTime);
            ___EndSyarin.eulerAngles = new Vector3(___FrontSyarin.eulerAngles.x, ___FrontSyarin.eulerAngles.y, ___FrontSyarin.eulerAngles.z - AngularVelocity * ShipDirection.x);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var hitObjectBoundable = collision.gameObject.GetComponent<IBoundable>();
            if(hitObjectBoundable!=null) ShipDirection.x *= -1;
        }
    }

}