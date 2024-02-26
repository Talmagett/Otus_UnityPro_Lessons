using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Heroes;
using Modules.Entities.Scripts.MonoBehaviours;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;
using Zenject;

namespace Game
{
    public class MouseInput : ITickable
    {
        public event Action<MonoEntity> HeroClickPerformed;
        
        public void Tick()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            var eventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };
            
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            foreach (var result in results)
            {
                if (result.gameObject.TryGetComponent(out MonoEntity proxy))
                {
                    HeroClickPerformed?.Invoke(proxy);
                }
            }
        }
    }
}