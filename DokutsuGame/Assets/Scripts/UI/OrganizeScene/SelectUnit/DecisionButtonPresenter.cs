using Assets.Scripts.UI.StartScene.Manager;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class DecisionButtonPresenter : MonoBehaviour
    {
        [SerializeField]
        private OrganizeDecision ___OrganizeDecision;

        [SerializeField]
        private BaseButton ___DecisionButton;

        [SerializeField]
        private MainManager ___MainManager;

        // Start is called before the first frame update
        void Start()
        {
            ___MainManager.onAsyncInitialize.Subscribe(_ => Initialize());

        }

        private void Initialize()
        {
            ___DecisionButton.onClicked.Subscribe(n =>
            {
                var _=___OrganizeDecision.decisionOrganizeUnits(___MainManager.getStage());
            });
        }
    }
}