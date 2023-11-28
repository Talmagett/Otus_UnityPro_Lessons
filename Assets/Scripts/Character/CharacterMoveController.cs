using Components;
using GameManager;
using Input;
using UnityEngine;

namespace Character
{
    public class CharacterMoveController : MonoBehaviour,
        IGameFixedUpdateListener
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private MoveComponent moveComponent;

        public void OnGameFixedUpdate(float deltaTime)
        {
            Move();
        }

        private void Move()
        {
            moveComponent.Move(new Vector2(inputManager.MoveDirection, 0) * Time.fixedDeltaTime);
        }
    }
}