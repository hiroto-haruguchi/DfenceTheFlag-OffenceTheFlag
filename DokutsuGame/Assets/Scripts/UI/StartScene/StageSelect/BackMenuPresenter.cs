using Assets.Scripts.UI.StartScene.Manager;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.StartScene.StageSelect
{
    public class BackMenuPresenter : MonoBehaviour
    {
        [SerializeField]
        private MainManager ___MainManager;
        [SerializeField]
        private BackMenuView ___BackMenuView;
        [SerializeField]
        private BaseButton ___BackMenuButton;

        // Start is called before the first frame update
        void Start()
        {
            ___MainManager.onInitialize.Subscribe(_ => Initialize());
        }

        private void Initialize() {
            ___BackMenuButton.onClicked.Subscribe(_ =>
            {
                ___MainManager.setCurrentSelectMode(___BackMenuView.getPreviousSelectMode());
            }).AddTo(this);
        
        }

    }
}