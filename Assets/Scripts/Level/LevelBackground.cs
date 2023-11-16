using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour
    {
        [SerializeField] private float startPositionY;
        [SerializeField] private float endPositionY;
        [SerializeField] private float movingSpeedY;

        private float positionX;
        private float positionZ;
        private Transform myTransform;

        private void Awake()
        {
            this.myTransform = this.transform;
            var position = this.myTransform.position;
            this.positionX = position.x;
            this.positionZ = position.z;
        }

        private void FixedUpdate()
        {
            if (this.myTransform.position.y <= this.endPositionY)
            {
                this.myTransform.position = new Vector3(
                    this.positionX,
                    this.startPositionY,
                    this.positionZ
                );
            }

            this.myTransform.position -= new Vector3(
                this.positionX,
                this.movingSpeedY * Time.fixedDeltaTime,
                this.positionZ
            );
        }
    }
}