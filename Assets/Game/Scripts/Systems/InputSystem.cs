using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Systems
{
    [UsedImplicitly]
    public class InputSystem : ITickable
    {
        private Plane _hPlane = new(Vector3.up, Vector3.zero);
        public Vector3 MoveDirection { get; private set; }
        public Vector3 MousePosition { get; private set; }

        public Vector3 MousePositionOnY { get; private set; }

        public void Tick()
        {
            Movement();
            Shoot();
            Mouse();
            MouseOnY();
        }

        public event Action OnShootRequest;

        private void MouseOnY()
        {
            var ray = Camera.main.ScreenPointToRay(MousePosition);

            float distance = 0;
            if (_hPlane.Raycast(ray, out distance)) MousePositionOnY = ray.GetPoint(distance);
        }

        private void Movement()
        {
            MoveDirection = Vector3.zero;
            if (Input.GetKey(KeyCode.W)) MoveDirection = Vector3.forward;

            if (Input.GetKey(KeyCode.S)) MoveDirection = Vector3.back;

            if (Input.GetKey(KeyCode.A)) MoveDirection = Vector3.left;

            if (Input.GetKey(KeyCode.D)) MoveDirection = Vector3.right;
        }

        private void Shoot()
        {
            if (Input.GetMouseButtonDown(0)) OnShootRequest?.Invoke();
        }

        private void Mouse()
        {
            MousePosition = Input.mousePosition;
        }
    }
}