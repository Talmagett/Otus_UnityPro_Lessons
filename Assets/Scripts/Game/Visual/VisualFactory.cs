// using Entities;
// using Lessons.Visual.Commands;
// using UnityEngine;
//
// namespace Lessons.Visual
// {
//     public sealed class VisualFactory : MonoBehaviour
//     {
//         [SerializeField]
//         private float moveSpeed = 5f;
//         
//         public IVisualCommand CreateMove(IEntity entity, Vector3 targetPosition)
//         {
//             return new MoveVisualCommand(this, entity, targetPosition, moveSpeed);
//         }
//     }
// }