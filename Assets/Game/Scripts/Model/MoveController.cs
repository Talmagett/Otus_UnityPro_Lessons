using Entity.Components;
using Systems;
using UnityEngine;
using Zenject;

namespace Model
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] private Entity.Entity entity;
        private IComponent_Move _componentMove;
        private InputSystem _inputSystem;

        [Inject]
        public void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }
        
        private void Start()
        {
            entity.TryComponent(out _componentMove);
        }

        private void Update()
        {
            if (_inputSystem.MoveDirection == Vector3.zero)
                return;

            _componentMove.Move(_inputSystem.MoveDirection);
        }
    }
}