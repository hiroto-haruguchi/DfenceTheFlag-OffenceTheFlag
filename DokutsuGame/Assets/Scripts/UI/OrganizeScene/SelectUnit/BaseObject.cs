using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.SelectUnit
{

    public class BaseObject : MonoBehaviour
    {
        protected UnitState State = UnitState.Holded;
        protected static Vector2 BattleSceneSize = new Vector2(14,9.5f);//バトルシーンでの配置範囲
        protected static Vector2 OrganizeSceneSize = new Vector2(27.5f, 19);//編成シーンでの配置範囲
        protected Vector2 BattleSceneShipCenter = new Vector2(-10.55f,-8.92f);//バトルシーンでのShipの中央
        protected Vector2 OrganizeSceneShipCenter = new Vector2(-4, -9.5f);//編成シーンでのShipの中央

        public IObservable<UnitState> onMouseEnter { get { return OnMouseEnterSubject; } }
        private Subject<UnitState> OnMouseEnterSubject = new Subject<UnitState>();

        public IObservable<UnitState> onMouseExit { get { return OnMouseExitSubject; } }
        private Subject<UnitState> OnMouseExitSubject = new Subject<UnitState>();

        public IObservable<UnitState> onMouseDraged { get { return OnMouseDragedSubject; } }
        private Subject<UnitState> OnMouseDragedSubject = new Subject<UnitState>();

        private void OnMouseEnter()
        {

            OnMouseEnterSubject.OnNext(State);
        }

        private void OnMouseExit()
        {
            //State = UnitState.Normal;
            OnMouseExitSubject.OnNext(State);

        }

        private void OnMouseDrag()
        {
            State = UnitState.Holded;
            OnMouseDragedSubject.OnNext(State);

        }

        private void OnMouseUp()
        {
            if ((this.transform.position.x < OrganizeSceneShipCenter.x + OrganizeSceneSize.x / 2))
            {
                State = UnitState.Normal;
            }
        }

        protected Vector3 ConvertToBattlePosition ()
        {
            float correctionX = (BattleSceneSize.x / OrganizeSceneSize.x);
            float correctionY = (BattleSceneSize.y / OrganizeSceneSize.y);

            float Ox = this.transform.position.x + Mathf.Abs(OrganizeSceneShipCenter.x);
            float Oy = this.transform.position.y + 1.5f;

            float Bx = correctionX * Ox;
            float By = correctionY * Oy;

            Vector3 ObjectPosition = new Vector3(BattleSceneShipCenter.x + Bx, (-BattleSceneSize.y / 2) + By, this.transform.position.z);

            Vector3 info = ObjectPosition;

            return info;
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
    }
}