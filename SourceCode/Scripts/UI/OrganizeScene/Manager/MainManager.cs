using UnityEngine;
using System;
using UniRx;
using Assets.Scripts.UI.StartScene.Manager;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{

    public class MainManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject ___Tutorial;
        [SerializeField]
        private GameObject ___TutorialNext;

        public IObservable<SceneDataPack> onAsyncInitialize { get { return OnAsyncInitialize; } }
        private AsyncSubject<SceneDataPack> OnAsyncInitialize=new AsyncSubject<SceneDataPack>();

        private  SceneDataPack SceneDataPack;

        private StageList SelectStage { get; set; } = new StageList();


        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1.0f;
            if (SceneDataPack.selectStage == StageList.Stage0)
            {

                ___Tutorial.SetActive(true);
                ___TutorialNext.SetActive(true);
            }
            OnAsyncInitialize.OnNext(SceneDataPack);
            OnAsyncInitialize.OnCompleted();
        }

        public void setStage(SceneDataPack dataPack)
        {
            SceneDataPack= dataPack;
            SelectStage = dataPack.selectStage;
        }

        public StageList getStage()
        {
            return SelectStage;
        }

        public SceneDataPack getDataPack()
        {
            return SceneDataPack;
        }
    }

}