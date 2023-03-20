using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.UI.StartScene.StageSelect
{
    public class StageViewMover : MonoBehaviour
    {
        private State NowState = State.Normal;
        public void fadeOutRight()
        {
            if (NowState == State.Normal)
            {

                NowState = State.Moving;

                transform.DOMove(new Vector3(10, 0, 0), duration: 0.2f)
                         .SetRelative(true)
                         .SetLink(gameObject);

                transform.DOMove(new Vector3(-10, 0, 0), duration: 0.001f)
                         .SetRelative(true)
                         .SetDelay(0.2f)
                         .OnComplete(() => NowState = State.Normal)
                         .SetLink(gameObject);
            }
        }

        public void fadeOutLeft()
        {
            if (NowState == State.Normal)
            {

                NowState = State.Moving;

                transform.DOMove(new Vector3(-10, 0, 0), duration: 0.2f)
                         .SetRelative(true)
                         .SetLink(gameObject);

                transform.DOMove(new Vector3(10, 0, 0), duration: 0.001f)
                         .SetRelative(true)
                         .SetDelay(0.2f)
                         .SetLink(gameObject)
                         .OnComplete(() => NowState = State.Normal);
            }
        }
        private enum State
        {
            Moving,
            Normal

        }
    }
}