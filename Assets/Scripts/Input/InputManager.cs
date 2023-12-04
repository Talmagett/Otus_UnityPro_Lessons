using System;
using UnityEngine;
using Zenject;

namespace Input
{
    public sealed class InputManager : ITickable
    {
        public float MoveDirection { get; private set; }
        public event Action OnFire;

        public void Tick()
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