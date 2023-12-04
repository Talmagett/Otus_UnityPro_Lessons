using Common;
using UnityEngine;
using Zenject;

namespace Bullets
{
    public class BulletSpawner
    {
        private Pool<Bullet> pool;
        
        private GameManager.GameManager _gameManager;
        private readonly Transform _worldTransform;

        [Inject]
        public BulletSpawner(GameManager.GameManager gameManager,Transform poolTransform,Transform worldTransform,Bullet bulletPrefab)
        {
            _gameManager = gameManager;
            _worldTransform = worldTransform;
            pool = new Pool<Bullet>(50,poolTransform,bulletPrefab);
        }

        public Bullet SpawnBullet()
        {
            var bullet = pool.GetInstance(_worldTransform);
            _gameManager.AddListeners(bullet.GetListeners());
            return bullet;
        }

        public void UnspawnBullet(Bullet bullet)
        {
            _gameManager.RemoveListeners(bullet.GetListeners());
            pool.Release(bullet);
        }
    }
}