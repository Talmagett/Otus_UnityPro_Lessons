using System;
using UnityEngine;

namespace Input
{
    public sealed class InputManager : MonoBehaviour
    {
        public float MoveDirection { get; private set; }
        public event Action OnFire;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                OnFire?.Invoke();
            }

            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                MoveDirection = -1;
            }
            else if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
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