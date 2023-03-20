using Assets.Scripts.UI.OrganaizeScene.Manager;
using Assets.Scripts.UI.StartScene.Manager;
using UniRx;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Assets.Scripts.UI.OrganaizeScene.Mnager
{
    public class SceneBackCreate : MonoBehaviour
    {
        [SerializeField]
        private MoneyCounter ___MoneyCounter;
        [SerializeField]
        private UI.OrganaizeScene.Manager.MainManager ___MainManager;

        [SerializeField]
        private CreateUnitPresenter ___CreateUnitPresenter;

        [SerializeField]
        private UnitProviderUI ___UnitProvider;
        [SerializeField]
        private BlockProviderUI ___BlockProvider;
        [SerializeField]
        private GameObject ___ShipCoreUI;

        private SceneDataPack DataPack;

        // Start is called before the first frame update
        async UniTask Start()
        {
            ___MainManager.onAsyncInitialize.Subscribe(x =>
            {
                DataPack = x;
            }).AddTo(this);

            await ___CreateUnitPresenter.onInitializeAsync();
            SetObject();
        }

        private void SetObject()
        {
            if (DataPack.playerUnitListOrganize != null)
            {
                foreach (var it in DataPack.playerUnitListOrganize)
                {
                    ___UnitProvider.createUnitBack(it);
                }
            }

            if (DataPack.playerBlockListOrgainze != null)
            {
                foreach (var it in DataPack.playerBlockListOrgainze)
                {
                    ___BlockProvider.createBlockBack(it);
                }
            
            }

            if (DataPack.playerShipCorePosOrganize != null)
            {
                ___ShipCoreUI.transform.position = DataPack.playerShipCorePosOrganize;
            }
        }
    }
}