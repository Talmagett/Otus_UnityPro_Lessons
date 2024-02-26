using System;
using System.Collections.Generic;
using Modules.Entities.Scripts.MonoBehaviours;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.Input
{
    public class MouseInput : ITickable
    {
        public void Tick()
        {
            if (!UnityEngine.Input.GetMouseButtonDown(0)) return;

            var eventData = new PointerEventData(EventSystem.current)
            {
                position = UnityEngine.Input.mousePosition
            };

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            foreach (var result in results)
                if (result.gameObject.TryGetComponent(out MonoEntity proxy))
                    HeroClickPerformed?.Invoke(proxy);
        }

        public event Action<MonoEntity> HeroClickPerformed;
    }
}