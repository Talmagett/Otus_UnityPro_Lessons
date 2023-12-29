using Components;
using GameManager;
using UnityEngine;

namespace Enemy.Agents
{
    public sealed class EnemyMoveAgent : IGameFixedUpdateListener
    {
        public bool IsReached { get; private set; }

        private readonly MoveComponent _moveComponent;
        private readonly Transform _transform;
        
        private Vector2 _destination;
        private const float ReachingDistance = 0.25f;

        public EnemyMoveAgent(MoveComponent moveComponent,Transform transform)
        {
            _moveComponent = moveComponent;
            _transform = transform;
        }
        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            IsReached = false;
        }

        public void OnGameFixedUpdate(float deltaTime)
        {
            if (IsReached) return;

            var vector = _destination - (Vector2)_transform.position;
            if (vector.magnitude <= ReachingDistance)
            {
                IsReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.Move(direction);
        }
    }
}