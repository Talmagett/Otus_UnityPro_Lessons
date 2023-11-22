using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    [System.Serializable]
    public class Pool<T> where T : Component
    {
        [Header("Pool")] 
        [SerializeField] private int initialCount = 50;

        [SerializeField] protected Transform container;
        [SerializeField] protected T prefab;
        
        private readonly Queue<T> _pool = new();

        public void InitSpawn()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var t = GameObject.Instantiate(prefab, container);
                _pool.Enqueue(t);
            }
        }

        public T GetInstance(Transform worldTransform=null)
        {
            if (_pool.TryDequeue(out T t))
            {
                t.transform.SetParent(worldTransform);
                return t;
            }
            return GameObject.Instantiate(prefab, worldTransform);
        }

        public void Release(T instance)
        {
            instance.transform.SetParent(container);
            _pool.Enqueue(instance);
        }
    }
}