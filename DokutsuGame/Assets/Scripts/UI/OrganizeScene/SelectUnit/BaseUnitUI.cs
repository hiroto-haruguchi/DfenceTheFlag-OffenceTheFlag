using Assets.Scripts.Manager;
using Assets.Scripts.UI.OrganaizeScene.Manager;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.SelectUnit
{
    public class BaseUnitUI : BaseObject
    {

        [SerializeField]
        private int Cost;
        
        //オブジェクトの配置できる場所の限界
        private static float MaxX = 19.75f;
        private static float MinX = -17.75f;
        private static float MaxY = 10;
        private static float MinY = -9;

        private Vector2 MousePosition;
        private Vector2 ScreenToWorld;
        private Vector3 AngularPosition;

        private Transform Transform;

        public UnitKindIs iAm = UnitKindIs.Nobody;
        private GameObject MoneyCounterObj;
        private MoneyCounter MoneyCounter;

        private void Start()
        {
            MoneyCounterObj=GameObject.Find("MoneyCounter");
            MoneyCounter=MoneyCounterObj.GetComponent<MoneyCounter>();
            MoneyCounter.GetComponent<MoneyCounter>();

        }
        void Update()
        {
            if (State == UnitState.Holded)
            {
                MoveWithMouseCurrsor();
            }

            if(State == UnitState.Selected)
            {
                RotateWithMousCurrsor();
                if(Input.GetMouseButtonDown(0)) State= UnitState.Normal;
            }
        }
        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (State == UnitState.Normal)
                {
                    State = UnitState.Selected;
                }
                else if (State == UnitState.Selected)
                {

                    Destroy(this.gameObject);

                }
            }
        }

        private void MoveWithMouseCurrsor()
        {

            Transform = this.transform;
            MousePosition = Input.mousePosition;
            ScreenToWorld = Camera.main.ScreenToWorldPoint(MousePosition);
            ScreenToWorld.x = Mathf.Clamp(ScreenToWorld.x, MinX, MaxX);
            ScreenToWorld.y = Mathf.Clamp(ScreenToWorld.y, MinY, MaxY);

            Transform.position = ScreenToWorld;

        }

        private void RotateWithMousCurrsor()
        {
            Transform = this.transform;
            MousePosition = Input.mousePosition;
            ScreenToWorld = Camera.main.ScreenToWorldPoint(MousePosition);
            AngularPosition = Transform.localEulerAngles;
            AngularPosition.z = 180 / Mathf.PI * Mathf.Clamp(Mathf.Atan2((ScreenToWorld.y - transform.position.y), (ScreenToWorld.x - transform.position.x)),0,Mathf.PI*0.25f);
            Transform.eulerAngles = AngularPosition;

        }

        public int getCost()
        {
            return Cost;
        }

        public void setState(UnitState state)
        {
            State = state;
        }

        public UnitRegistrationInfo registerUnitInfo()
        {

            UnitRegistrationInfo info = new UnitRegistrationInfo(ConvertToBattlePosition(), this.transform.eulerAngles, 0,iAm,Damage.DogTag.Friend);

            return info;

        }

        public UnitRegistrationInfo registerUnitInfoOrganize()
        {
            UnitRegistrationInfo info = new UnitRegistrationInfo(transform.position, transform.eulerAngles, 0, iAm, Damage.DogTag.Friend);

            return info;
        }


        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
        private void OnDestroy()
        {
            if(MoneyCounter!=null) MoneyCounter.setMoney(Cost);
            State = UnitState.Normal;
        }
    }
}