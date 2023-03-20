using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.SelectUnit
{
    public class BaseShipCoreUI : BaseObject
    {

        //オブジェクトの配置できる場所の限界
        private float MaxX = 9.75f;
        private float MinX = -17.75f;
        private float MaxY = 10;
        private float MinY = -9;

        private Vector2 MousePosition;
        private Vector2 ScreenToWorld;
        private Transform Transform;

        void Start()
        {
            var sr=gameObject.GetComponent<SpriteRenderer>();
            var width = sr.bounds.size.x;
            var height = sr.bounds.size.y;

            MaxX = MaxX - (width/2-3);
            MinX= MinX + (width/2-0.5f);
            MaxY=MaxY- (height/2);
            MinY= MinY + (height/2);
            State = UnitState.Normal;
        }

        void Update()
        {
            if (State == UnitState.Holded)
            {
                MoveWithMouseCurrsor();
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

        public Vector3 registerShipCoreInfo()
        {

            return ConvertToBattlePosition();

        }

        public Vector3 registerShipCoreInfoOrganize()
        {

            return transform.position;

        }
    }

}