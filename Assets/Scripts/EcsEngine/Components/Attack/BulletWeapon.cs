using System;
using Leopotam.EcsLite.Entities;

namespace EcsEngine.Components.Attack
{
    [Serializable]
    public struct BulletWeapon
    {
        public UnityEngine.Transform firePoint;
        public Entity bulletPrefab;
    }
}