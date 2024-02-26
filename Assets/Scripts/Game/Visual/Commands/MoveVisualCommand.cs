// using Entities;
// using Lessons.Entities.Common.Components;
// using UnityEngine;
//
// namespace Lessons.Visual.Commands
// {
//     public sealed class MoveVisualCommand : UpdateVisualCommand
//     {
//         private readonly PositionComponent _position;
//         private readonly Vector3 _targetPosition;
//         private readonly float _speed;
//
//         public MoveVisualCommand(MonoBehaviour coroutineManager, IEntity entity, Vector3 targetPosition, float speed) :
//             base(coroutineManager)
//         {
//             _position = entity.Get<PositionComponent>();
//             _targetPosition = targetPosition;
//             _speed = speed;
//         }
//
//         protected override void OnUpdate()
//         {
//             var distance = _targetPosition - _position.Value;
//             
//             if (distance.sqrMagnitude >= Vector3.kEpsilon)
//             {
//                 _position.Value += (_targetPosition - _position.Value).normalized * (_speed * Time.deltaTime);
//             }
//             else
//             {
//                 _position.Value = _targetPosition;
//                 Return();
//             }
//         }
//     }
// }

