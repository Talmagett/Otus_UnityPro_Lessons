// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Lessons.Visual.Commands;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace Lessons.Visual
// {
//     public sealed class VisualManager : MonoBehaviour
//     {
//         public event Action Finished;
//
//         [ReadOnly, ShowInInspector]
//         private bool IsRunning => _currentCommand is not null;
//         
//         private readonly Queue<IVisualCommand> _commands = new();
//
//         private IVisualCommand _currentCommand;
//         
//         public void Add(IVisualCommand command)
//         {
//             _commands.Enqueue(command);
//             
//             if (_currentCommand is null)
//             {
//                 StartNext();
//             }
//         }
//
//         private void StartNext()
//         {
//             if (!_commands.Any())
//             {
//                 _currentCommand = null;
//                 Finished?.Invoke();
//                 
//                 return;
//             }
//
//             _currentCommand = _commands.Dequeue();
//             _currentCommand.Start(StartNext);
//         }
//     }
// }