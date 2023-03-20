using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.SelectUnit
{

    public abstract class BaseViewer : MonoBehaviour
    {
        [SerializeField]
        protected int Responsible;

        private State NowState = State.Normal;

        public void fadeOutRight()
        {
            if (NowState == State.Normal) {
                
                NowState = State.Moving;
                
                transform.DOMove(new Vector3(1, 0, 0), duration: 0.1f)
                         .SetRelative(true);

                transform.DOMove(new Vector3(-1, 0, 0), duration: 0.1f)
                         .SetRelative(true)
                         .SetDelay(0.2f)
                         .OnComplete(()=>NowState=State.Normal);
            }
        }

        public void fadeOutLeft()
        {
            if (NowState == State.Normal)
            {

                NowState = State.Moving;

                transform.DOMove(new Vector3(-1, 0, 0), duration: 0.1f)
                         .SetRelative(true);

                transform.DOMove(new Vector3(1, 0, 0), duration: 0.1f)
                         .SetRelative(true)
                         .SetDelay(0.2f)
                         .OnComplete(() => NowState = State.Normal);
            }
        }

        public void setActiveMode(bool value)
        {
            gameObject.SetActive(value);
        }

        private enum State
        {
            Moving,
            Normal

        }
    }


}