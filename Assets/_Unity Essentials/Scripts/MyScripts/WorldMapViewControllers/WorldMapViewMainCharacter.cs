using System;
using UnityEngine;

namespace _Unity_Essentials.Scripts.MyScripts.WorldMapViewControllers
{
    public class WorldMapViewMainCharacter : MonoBehaviour
    {
        [Header("Information")] public float elaspedTime = 0f;
        public Vector3 targetPosition;
        public Vector3 initialPosition;

        private void Awake()
        {
            targetPosition = initialPosition = transform.position;
        }

        private void Update()
        {
            elaspedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elaspedTime / 0.5f);
        }

        public void MoveTo(Vector3 newPosition)
        {
            elaspedTime = 0f;
            targetPosition = newPosition;
            initialPosition = transform.position;
        }
    }
}