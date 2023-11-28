using GameManager;
using UnityEngine;

namespace Level
{
    public sealed class LevelBackground : MonoBehaviour,
        IGameFixedUpdateListener
    {
        [SerializeField] private float startPositionY;
        [SerializeField] private float endPositionY;
        [SerializeField] private float movingSpeedY;

        private float _positionX;
        private float _positionZ;
        private Transform _myTransform;

        private void Awake()
        {
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        public void OnGameFixedUpdate(float deltaTime)
        {
            if (_myTransform.position.y <= endPositionY)
                _myTransform.position = new Vector3(
                    _positionX,
                    startPositionY,
                    _positionZ
                );

            _myTransform.position -= new Vector3(
                _positionX,
                movingSpeedY * Time.fixedDeltaTime,
                _positionZ
            );
        }
    }
}