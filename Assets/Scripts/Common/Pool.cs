using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common
{
    [Serializable]
    public class Pool<T> where T : Component
    {
        [Header("Pool")] [SerializeField] private int initialCount = 50;

        [SerializeField] protected Transform container;
        [SerializeField] protected T prefab;

        private readonly Queue<T> _pool = new();

        public Pool(int initialCount,Transform container, T prefab)
        {
            this.initialCount = initialCount;
            this.container = container;
            this.prefab = prefab;
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