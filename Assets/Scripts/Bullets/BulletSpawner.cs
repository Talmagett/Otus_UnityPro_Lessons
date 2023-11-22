using UnityEngine;

namespace ShootEmUp
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Pool<Bullet> pool;
        [SerializeField] private Transform worldTransform;

        private void Awake()
        {
            pool.InitSpawn();
        }

        public Bullet SpawnBullet()
        {
            var bullet = pool.GetInstance(worldTransform);
            return bullet;
        }

        public void UnspawnBullet(Bullet bullet)
        {
            pool.Release(bullet);
        }
    }
}