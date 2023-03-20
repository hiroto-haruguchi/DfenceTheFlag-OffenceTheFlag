using Assets.Scripts.UI.StartScene.Manager;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.StartScene.StageSelect
{
    public class StageViewPresenter : MonoBehaviour
    {
        [SerializeField]
        private BaseButton ___RightButton;
        [SerializeField]
        private BaseButton ___LeftButton;
        [SerializeField]
        private StageViewMover ___StageView;
        [SerializeField]
        private MainManager ___MainManager;

        // Start is called before the first frame update
        void Start()
        {
            ___MainManager.onInitialize.Subscribe(_=>Initialize()).AddTo(this);
        }

        private void Initialize()
        {
            ___RightButton.onClicked.Subscribe(_=>___StageView.fadeOutRight()).AddTo(this);
            ___LeftButton.onClicked.Subscribe(_ => ___StageView.fadeOutLeft()).AddTo(this);
        }
    }
}