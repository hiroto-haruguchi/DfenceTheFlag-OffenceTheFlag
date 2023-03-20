using UnityEngine;


namespace Assets.Scripts.Ship
{

    public abstract class ShipComponent : MonoBehaviour
    {
        protected ShipCore Core;
        // Start is called before the first frame update
        void Start()
        {
            Core = GetComponent<ShipCore>();
        }

    }
}