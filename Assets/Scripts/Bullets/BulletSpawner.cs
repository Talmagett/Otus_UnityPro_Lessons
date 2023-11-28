using Common;
using GameManager;
using UnityEngine;

namespace Bullets
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Pool<Bullet> pool;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private GameManager.GameManager gameManager;

        private void Awake()
        {
            pool.InitSpawn();
        }

        public Bullet SpawnBullet()
        {
            var bullet = pool.GetInstance(worldTransform);
            gameManager.AddListeners(bullet.GetListeners());
            return bullet;
        }

        public void UnspawnBullet(Bullet bullet)
        {
            gameManager.RemoveListeners(bullet.GetListeners());
            pool.Release(bullet);
        }
    }
}