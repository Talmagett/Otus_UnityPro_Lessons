using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class PoolSystem<T> : MonoBehaviour where T : Object
    {
        [Header("Pool")] 
        [SerializeField] private int initialCount = 50;

        [SerializeField] protected Transform container;
        [SerializeField] protected T prefab;
        [SerializeField] protected Transform worldTransform;
        
        private readonly Queue<T> _pool = new();

        private void Awake()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var t = Instantiate(prefab, container);
                _pool.Enqueue(t);
            }
        }

        public T GetInstance()
        {
            return _pool.Dequeue();
        }

        public void Release(T instance)
        {
            _pool.Enqueue(instance);
        }
    }
}