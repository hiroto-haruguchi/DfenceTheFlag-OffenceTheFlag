using Assets.Scripts.UI.BattleScene;
using Assets.Scripts.Ship;
using Assets.Scripts.UI.StartScene.Manager;
using UniRx;
using UnityEngine;
using Assets.Scripts.Save;

namespace Assets.Scripts.Manager
{

    public class BattleJudge : MonoBehaviour
    {
        [SerializeField]
        private MainGameManager ___MainGameManager;

        [SerializeField]
        private ShipCoreHitPointMonitor ___PlayerShipCore;
        [SerializeField]
        private ShipCoreHitPointMonitor ___EnemyShipCore;

        [SerializeField]
        private GameObject ___Win;
        private BaseWin WinAnimation;

        [SerializeField]
        private GameObject ___Lose;
        private BaseLose LoseAnimation;

        [SerializeField]
        private BaseButton ___DebugButton;

        [SerializeField]
        private GameObject ___StageSelect;
        [SerializeField]
        private GameObject ___StartMenu;


        private GameState CurrentGameIs = GameState.Ongoing;
        private ManagementData Progress;

        // Start is called before the first frame update
        void Start()
        {
            WinAnimation = ___Win.GetComponent<BaseWin>();
            LoseAnimation = ___Lose.GetComponent<BaseLose>();

            ___MainGameManager.onAsyncInitialize.Subscribe(x => Progress = x);

            ___PlayerShipCore.shipCoreHitPoint.Subscribe(HitPoint => {
                if (HitPoint <= 0) GameEnd(WinnerTag.Enemy);
            });

            ___EnemyShipCore.shipCoreHitPoint.Subscribe(HitPoint => {
                if (HitPoint <= 0) GameEnd(WinnerTag.Player);
            });

            ___DebugButton.onClicked.Subscribe(_ =>GameEnd(WinnerTag.Player));

        }

        private void GameEnd(WinnerTag winner)
        {
            Time.timeScale = 0.1f;
            

            if (winner == WinnerTag.Player)
            {
                if (CurrentGameIs == GameState.End) return;//Once only GameEndAnimation
                CurrentGameIs = GameState.End;

                ___Win.SetActive(true);
                ___StageSelect.SetActive(true);
                ___StartMenu.SetActive(true);
                WinAnimation.onAnimate();

                if (Progress.selectStage == StageList.Stage0) return;//If Tutorial do not update progress information


                //update progress information
                if (Progress.getData(Progress.selectStage)==false) Progress.setMoney(100);
                Progress.setData(Progress.selectStage,true);

                string filePath = Application.dataPath + "/savedata.xml";
                DataUtil.saveXML(filePath, Progress);

            }else if(winner == WinnerTag.Enemy)
            {
                if (CurrentGameIs == GameState.End) return;//Once only GameEndAnimation
                CurrentGameIs = GameState.End;

                ___Lose.SetActive(true);
                ___StageSelect.SetActive(true);
                ___StartMenu.SetActive(true);
                LoseAnimation.onAnimate();
            }

        }

        enum WinnerTag
        {
            Player,
            Enemy
        }

        enum GameState
        {
            Ongoing,
            End
        }
    }
}