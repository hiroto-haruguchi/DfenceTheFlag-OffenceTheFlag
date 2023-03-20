using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class NumberViewWarehouse : MonoBehaviour
    {
        [SerializeField]
        private Sprite ___Zero;
        [SerializeField]
        private Sprite ___One;
        [SerializeField]
        private Sprite ___Two;
        [SerializeField]
        private Sprite ___Three;
        [SerializeField]
        private Sprite ___Four;
        [SerializeField]
        private Sprite ___Five;
        [SerializeField]
        private Sprite ___Six;
        [SerializeField]
        private Sprite ___Seven;
        [SerializeField]
        private Sprite ___Eight;
        [SerializeField]
        private Sprite ___Nine;

        public Sprite getNumberSprite(int number)
        {
            switch (number)
            {
                case 0:
                    return ___Zero;
                case 1:
                    return ___One;
                case 2:
                    return ___Two;
                case 3:
                    return ___Three;
                case 4:
                    return ___Four;
                case 5:
                    return ___Five;
                case 6:
                    return ___Six;
                case 7:
                    return ___Seven;
                case 8:
                    return ___Eight;
                case 9:
                    return ___Nine;
                default:
                    return ___Zero;
            }
        }
    }
}