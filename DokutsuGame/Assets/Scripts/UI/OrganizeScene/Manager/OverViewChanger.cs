using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.OrganaizeScene.Mangaer
{


    public class OverViewChanger : MonoBehaviour
    {
        [SerializeField]
        private Image ___MyImage;
        [SerializeField]
        private OverViewImageWarehouse ___Warehouse;

        public void changeOverView<T>(T currentView)
        {
            ___MyImage.sprite = ___Warehouse.getOverViewImageSprite(currentView);
        }
    }
}