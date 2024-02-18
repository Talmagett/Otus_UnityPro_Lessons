using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entity
{
    public class Entity : MonoBehaviour
    {
        private readonly List<object> _components = new();

        public void Add<T>(T component)
        {
            _components.Add(component);
        }

        public bool TryComponent<T>(out T component)
        {
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i] is T value)
                {
                    component = value;
                    return true;
                }
            }

            component = default;
            return false;
        }

        public T Component<T>()
        {
            for (int i = 0; i < _components.Count; i++)
            {
                if (_components[i] is T value)
                {
                    return value;
                }
            }

            throw new Exception($"Component {typeof(T)} not find");
        }
    }
}