using UnityEngine;

namespace Common
{
    [System.Serializable]
    public struct PoolArgs<T>
    {
        public T Prefab;
        public Transform Container;
        public int InitialCount;
        public Transform WorldTransform;
    }
}