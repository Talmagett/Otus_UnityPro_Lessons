using Bullets;
using UnityEngine;

namespace Components
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public Vector2 Position => firePoint.position;
        public Quaternion Rotation => firePoint.rotation;
        public BulletConfig BulletConfig => bulletConfig;

        [SerializeField] private Transform firePoint;
        [SerializeField] private BulletConfig bulletConfig;
    }
}