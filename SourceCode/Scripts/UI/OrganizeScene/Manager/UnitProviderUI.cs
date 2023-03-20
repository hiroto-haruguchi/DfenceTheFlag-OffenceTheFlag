using Assets.Scripts.Manager;
using Assets.Scripts.UI.OrganaizeScene.SelectUnit;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class UnitProviderUI : MonoBehaviour
    {
        [SerializeField]
        private MoneyCounter ___MoneyCounter;

        [SerializeField]
        private GameObject ___Nobody;

        [SerializeField]
        private GameObject ___NormalUnit;

        [SerializeField]
        private GameObject ___Dragoon;

        [SerializeField]
        private GameObject ___Ninja;

        [SerializeField]
        private GameObject ___Samurai;

        [SerializeField]
        private GameObject ___Magi;

        [SerializeField]
        private GameObject ___Gunman;

        [SerializeField]
        private GameObject ___Sniper;

        [SerializeField]
        private GameObject ___Launcher;

        [SerializeField]
        private GameObject ___Fighter;

        [SerializeField]
        private GameObject ___Ranger;

        public IReactiveCollection<GameObject> unitList { get { return UnitList; } }

        private readonly ReactiveCollection<GameObject> UnitList = new ReactiveCollection<GameObject>();
        

        public void createUnit(UnitKindIs kind)
        {
            if(kind!=UnitKindIs.Nobody) GetUnit(kind);
        }

        public void createUnitBack(UnitRegistrationInfo info)
        {
            var unit = Instantiate(SelectUnit(info.unitIs), info.pos, Quaternion.Euler(info.angle));
            var unitUi = unit.GetComponent<BaseUnitUI>();
            unitUi.iAm = info.unitIs;
            unitUi.setState(UnitState.Normal);

            if (___MoneyCounter.canBuy(unitUi.getCost()) == false)
            {
                Destroy(unit);
                return;

            }
            else ___MoneyCounter.setMoney(-unitUi.getCost());

            UnitList.Add(unit);
        }

        private void GetUnit(UnitKindIs kind)
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 cursorToWorld = Camera.main.ScreenToWorldPoint(mousePosition);
            var unit = Instantiate(SelectUnit(kind), cursorToWorld, Quaternion.identity);
            var unitUi=unit.GetComponent<BaseUnitUI>();
            unitUi.iAm = kind;

            if (___MoneyCounter.canBuy(unitUi.getCost()) == false)
            {
                Destroy(unit);
                return;

            }
            else ___MoneyCounter.setMoney(-unitUi.getCost());

            UnitList.Add(unit);
        
        }
        private GameObject SelectUnit(UnitKindIs kind)
        {
            GameObject unitObj = null;

            switch (kind)
            {
                case UnitKindIs.Nobody:
                    unitObj = ___Nobody;
                    return unitObj;
                case UnitKindIs.NormalUnit:
                    unitObj = ___NormalUnit;
                    return unitObj;
                case UnitKindIs.Dragoon:
                    unitObj = ___Dragoon;
                    return unitObj;
                case UnitKindIs.Ninja:
                    unitObj = ___Ninja;
                    return unitObj;
                case UnitKindIs.Samurai:
                    unitObj = ___Samurai;
                    return unitObj;
                case UnitKindIs.Magi:
                    unitObj = ___Magi;
                    return unitObj;
                case UnitKindIs.Gunman:
                    unitObj = ___Gunman;
                    return unitObj;
                case UnitKindIs.Sniper:
                    unitObj = ___Sniper;
                    return unitObj;
                case UnitKindIs.Launcher:
                    unitObj = ___Launcher;
                    return unitObj;
                case UnitKindIs.Fighter:
                    unitObj = ___Fighter;
                    return unitObj;
                case UnitKindIs.Ranger:
                    unitObj = ___Ranger;
                    return unitObj;
                default:
                    return null;
            }

        }
    }


}