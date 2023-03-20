using Assets.Scripts.Manager;
using Assets.Scripts.UI.OrganaizeScene.Manager;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.SelectUnit
{
    public class BaseBlockUI : BaseObject
    {
        [SerializeField]
        private int Cost;

        //オブジェクトの配置できる場所の限界
        private  float MaxX = 19.75f;
        private  float MinX = -17.75f;
        private  float MaxY = 10;
        private  float MinY = -9;

        private Vector2 MousePosition;
        private Vector2 ScreenToWorld;
        private Transform Transform;
        public BlockKindIs iAm = BlockKindIs.Nobody;


        private GameObject MoneyCounterObj;
        private MoneyCounter MoneyCounter;


        void Start()
        {
            var sr = gameObject.GetComponent<SpriteRenderer>();
            var width = sr.bounds.size.x;
            var height = sr.bounds.size.y;

            MinX = MinX + (width / 2);
            MaxY = MaxY - (height / 2);
            MinY = MinY + (height / 2);

            MoneyCounterObj = GameObject.Find("MoneyCounter");
            MoneyCounter = MoneyCounterObj.GetComponent<MoneyCounter>();

        }
        void Update()
        {
            if (State == UnitState.Holded)
            {
                MoveWithMouseCurrsor();
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
                    MoneyCounter.GetComponent<MoneyCounter>().setMoney(Cost);
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

        public void setState(UnitState state)
        {
            State = state;
        }

        public int getCost()
        {
            return Cost;
        }

        public BlockRegistrationInfo registerBlockInfo()
        {
            BlockRegistrationInfo info = new BlockRegistrationInfo(ConvertToBattlePosition(), iAm, Damage.DogTag.Friend);

            return info;

        }

        public BlockRegistrationInfo registerBlockInfoOrganize()
        {
            BlockRegistrationInfo info = new BlockRegistrationInfo(transform.position, iAm, Damage.DogTag.Friend);

            return info;

        }
    }
}