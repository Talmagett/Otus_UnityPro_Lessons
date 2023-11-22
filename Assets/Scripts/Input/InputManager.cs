using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public float MoveDirection { get; private set; }
        public event Action OnFire;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFire?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveDirection = 1;
            }
            else
            {
                MoveDirection = 0;
            }
        }
    }
}