using Common;
using UnityEngine;
using Zenject;

namespace Bullets
{
    public class BulletSpawner
    {
        private readonly Pool<Bullet> _pool;
        
        private readonly GameManager.GameManager _gameManager;
        private readonly Transform _worldTransform;

        [Inject]
        public BulletSpawner(GameManager.GameManager gameManager,PoolArgs<Bullet> bulletPoolArgs)
        {
            _gameManager = gameManager;
            _worldTransform = bulletPoolArgs.WorldTransform;
            _pool = new Pool<Bullet>(bulletPoolArgs.Prefab,bulletPoolArgs.Container,bulletPoolArgs.InitialCount);
        }

        public Bullet SpawnBullet()
        {
            var bullet = _pool.GetInstance(_worldTransform);
            _gameManager.AddListeners(bullet.GetListeners());
            return bullet;
        }

        public void UnspawnBullet(Bullet bullet)
        {
            _gameManager.RemoveListeners(bullet.GetListeners());
            _pool.Release(bullet);
        }
    }
}