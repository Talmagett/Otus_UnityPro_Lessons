using Entity.Components;
using Systems;
using UnityEngine;
using Zenject;

namespace Model
{
    public class RotationController : MonoBehaviour
    {
        [SerializeField] private Entity.Entity entity;

        private InputSystem _inputSystem;
        private IComponent_Rotation _componentRotation;
        private IComponent_Position _componentPosition;


        [Inject]
        public void Construct(InputSystem inputSystem)
        {
            _inputSystem = inputSystem;
        }

        private void Start()
        {
            entity.TryComponent(out _componentRotation);
            entity.TryComponent(out _componentPosition);
        }

        private void Update()
        {
            var direction = (_inputSystem.MousePositionOnY - _componentPosition.GetPosition()).normalized;
            _componentRotation.Rotate(direction);
        }
    }
}