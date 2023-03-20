using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.UI.BattleScene
{
    public class BaseWin : MonoBehaviour
    {
        public void onAnimate()
        {
            transform.DOLocalMove(new Vector3(0, 0, 0), duration: 0.1f)
                     .SetLink(gameObject);
        }
    }
}