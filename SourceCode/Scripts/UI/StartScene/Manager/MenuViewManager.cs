using UnityEngine;

namespace Assets.Scripts.UI.StartScene.Manager
{
    public class MenuViewManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject Title;
        [SerializeField]
        private GameObject SelectStageView;
        [SerializeField]
        private GameObject ExitGameView;
        [SerializeField]
        private GameObject Tutorial;
        [SerializeField]
        private GameObject StageView;
        [SerializeField]
        private GameObject StageViewRightMove;
        [SerializeField]
        private GameObject StageViewLeftMove;
        [SerializeField]
        private GameObject BackMenu;

        public void setStartMode()
        {
            Title.SetActive(true);
            SelectStageView.SetActive(true);
            ExitGameView.SetActive(true);
            Tutorial.SetActive(true);
            StageView.SetActive(false);
            StageViewRightMove.SetActive(false);
            StageViewLeftMove.SetActive(false);
            StageViewRightMove.SetActive(false);
            BackMenu.SetActive(false);
        }

        public void setStageSelectMode()
        {
            Title.SetActive(false);
            SelectStageView.SetActive(false);
            ExitGameView.SetActive(false);
            Tutorial.SetActive(false);
            StageView.SetActive(true);
            StageViewRightMove.SetActive(true);
            StageViewLeftMove.SetActive(true);
            StageViewRightMove.SetActive(true);
            BackMenu.SetActive(true);

        }


    }

}