using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common
{
    [Serializable]
    public class Pool<T> where T : Component
    {
        [Header("Pool")]

        [SerializeField] protected T prefab;
        [SerializeField] protected Transform container;
        [SerializeField] private int initialCount = 50;

        private readonly Queue<T> _pool = new();

        public Pool(T prefab,Transform container, int initialCount)
        {
            this.prefab = prefab;
            this.container = container;
            this.initialCount = initialCount;
            InitSpawn();
        }
        
        private void InitSpawn()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var t = Object.Instantiate(prefab, container);
                _pool.Enqueue(t);
            }
        }

        public T GetInstance(Transform worldTransform = null)
        {
            if (_pool.TryDequeue(out var t))
            {
                t.transform.SetParent(worldTransform);
                return t;
            }

            return Object.Instantiate(prefab, worldTransform);
        }

        public void Release(T instance)
        {
            instance.transform.SetParent(container);
            _pool.Enqueue(instance);
        }
    }
}