using EcsEngine.Components.Movement;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace GameSystems
{
    internal sealed class CharacterMoveController : MonoBehaviour
    {
        [SerializeField] private Entity character;

        [SerializeField] private MoveInput input;

        private void Update()
        {
            var inputDirection = input.GetDirection();
            ref var moveDirection = ref character.GetData<MoveDirection>();
            moveDirection.value = inputDirection;
        }
    }
}