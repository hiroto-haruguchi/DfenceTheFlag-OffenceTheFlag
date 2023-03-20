using Assets.Scripts.UI.StartScene.Manager;
using UnityEngine;

namespace Assets.Scripts.UI.StartScene.StageSelect
{
    public class BackMenuView : MonoBehaviour
    {
        private SelectMode PreviousSelectMode;

        public void setPreviousSelectMode(SelectMode mode) 
        {
            PreviousSelectMode = mode;
        }

        public SelectMode getPreviousSelectMode() { return PreviousSelectMode; }


    }
}