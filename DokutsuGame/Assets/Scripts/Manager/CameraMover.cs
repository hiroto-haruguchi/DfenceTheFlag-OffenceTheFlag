using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Mangaer
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField]
        private GameObject ___PlayerShip;
        [SerializeField]
        private GameObject ___EnemyShip;
        [SerializeField]
        private Camera ___Camera;

        private const int WindowSizeX = 16;
        private const int WindowSizeY = 9;

        private const float WindowAspect=WindowSizeX/WindowSizeY;

        private float PlayerToEnemyDistance = 0.0f;

        private float ShipDistanceThreshold = 21.54f;

        private const float DefaultCameraSize = 10.0f;


        // Update is called once per frame
        void Update()
        {
            PlayerToEnemyDistance = Mathf.Abs(___PlayerShip.transform.position.x -___EnemyShip.transform.position.x);
            if(PlayerToEnemyDistance > ShipDistanceThreshold)
            {
                ___Camera.orthographicSize = DefaultCameraSize + WindowAspect * (PlayerToEnemyDistance- ShipDistanceThreshold);
                ___Camera.transform.position = new Vector3(-WindowAspect * (PlayerToEnemyDistance - ShipDistanceThreshold), (PlayerToEnemyDistance - ShipDistanceThreshold),-10);
            }
        }
    }
}