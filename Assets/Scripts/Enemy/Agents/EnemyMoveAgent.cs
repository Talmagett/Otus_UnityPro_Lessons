using Components;
using GameManager;
using UnityEngine;

namespace Enemy.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour,
        IGameFixedUpdateListener
    {
        public bool IsReached { get; private set; }

        [SerializeField] private MoveComponent moveComponent;
        private Vector2 _destination;
        private const float ReachingDistance = 0.25f;

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            IsReached = false;
        }

        public void OnGameFixedUpdate(float deltaTime)
        {
            if (IsReached) return;

            var vector = _destination - (Vector2)transform.position;
            if (vector.magnitude <= ReachingDistance)
            {
                IsReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            moveComponent.Move(direction);
        }
    }
}