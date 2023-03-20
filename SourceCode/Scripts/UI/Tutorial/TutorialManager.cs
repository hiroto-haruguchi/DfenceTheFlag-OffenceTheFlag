using Assets.Scripts.UI.StartScene.Manager;
using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.UI.Tutorial
{
    public class TutorialManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject ___Tutorial1;
        [SerializeField]
        private GameObject ___Tutorial2;
        [SerializeField]
        private GameObject ___Tutorial3;
        [SerializeField]
        private GameObject ___Tutorial4;
        [SerializeField]
        private GameObject ___Tutorial5;
        [SerializeField]
        private GameObject ___Tutorial6;
        [SerializeField]
        private GameObject ___Next;


        public IObservable<UniRx.Unit> onAsyncInitialize { get { return OnAsyncInitialize; } }
        private AsyncSubject<UniRx.Unit> OnAsyncInitialize = new AsyncSubject<UniRx.Unit>();

        private IntReactiveProperty ClickCount = new IntReactiveProperty(0);
        // Start is called before the first frame update
        void Start()
        {
            OnAsyncInitialize.OnNext(UniRx.Unit.Default);
            OnAsyncInitialize.OnCompleted();

            ___Next.GetComponent<BaseButton>().onClicked.Subscribe(_ => ClickCount.Value++);

            ClickCount.Subscribe(x => SetTutorial(x));
        }

        private void  SetTutorial(int count)
        {
            switch (count)
            {
                case 1:
                    ___Tutorial1.SetActive(true);
                    break;
                case 2:
                    ___Tutorial1.SetActive(false);
                    ___Tutorial2.SetActive(true);
                    break;
                case 3:
                    ___Tutorial2.SetActive(false);
                    ___Tutorial3.SetActive(true);
                    break;
                case 4:
                    ___Tutorial3.SetActive(false);
                    ___Tutorial4.SetActive(true);
                    break;
                case 5:
                    ___Tutorial4.SetActive(false);
                    ___Tutorial5.SetActive(true);
                    break;
                case 6:
                    ___Tutorial5.SetActive(false);
                    ___Tutorial6.SetActive(true);
                    break;
                case 7:
                    ___Tutorial6.SetActive(false);
                    ___Next.SetActive(false);
                    ClickCount.Dispose();
                    break;
                default:
                    break;
            }
        }
    }
}