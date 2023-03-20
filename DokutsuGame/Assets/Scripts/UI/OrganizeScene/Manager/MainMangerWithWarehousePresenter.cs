using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class MainMangerWithWarehousePresenter : MonoBehaviour
    {
        [SerializeField]
        private MainManager ___MainManager;
        [SerializeField]
        private SourceImageWarehouse ___ImageWareHouse;

        // Start is called before the first frame update
        void Start()
        {
            ___MainManager.onAsyncInitialize.Subscribe(x => ___ImageWareHouse.progress=x.progress).AddTo(this);
        }
    }
}