using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveController:MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private MoveComponent moveComponent;

        private void FixedUpdate()
        {
            Move();
        }
        private void Move()
        {
            moveComponent.Move(new Vector2(inputManager.MoveDirection, 0) * Time.fixedDeltaTime);
        }
    }
}