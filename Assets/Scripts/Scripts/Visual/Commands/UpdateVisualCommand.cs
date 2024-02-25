// using System;
// using System.Collections;
// using UnityEngine;
//
// namespace Lessons.Visual.Commands
// {
//     public abstract class UpdateVisualCommand : IVisualCommand
//     {
//         private readonly MonoBehaviour _coroutineManager;
//
//         private Action _callback;
//         private Coroutine _coroutine;
//         
//         protected UpdateVisualCommand(MonoBehaviour coroutineManager)
//         {
//             _coroutineManager = coroutineManager;
//         }
//
//         void IVisualCommand.Start(Action callback)
//         {
//             _callback = callback;
//             _coroutine = _coroutineManager.StartCoroutine(UpdateCoroutine());
//         }
//
//         protected void Return()
//         {
//             if (_coroutine != null)
//             {
//                 _coroutineManager.StopCoroutine(_coroutine);
//             }
//             
//             _callback.Invoke();
//         }
//
//         protected virtual void OnUpdate()
//         {
//             
//         }
//         
//         private IEnumerator UpdateCoroutine()
//         {
//             while (true)
//             {
//                 OnUpdate();
//                 yield return null;
//             }
//         }
//     }
// }