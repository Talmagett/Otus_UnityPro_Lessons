using System;
using System.Collections.Generic;
    using GameManager;
using Level;
using UnityEngine;
using Zenject;

namespace Bullets
{
    public sealed class BulletSystem : 
        IFixedTickable
    {
        private readonly BulletSpawner _bulletSpawner;
        private LevelBounds _levelBounds;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();

        public BulletSystem(BulletSpawner bulletSpawner, LevelBounds levelBounds)
        {
            _bulletSpawner = bulletSpawner;
            _levelBounds = levelBounds;
        }

        private void CheckOutsideBounds()
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                    RemoveBullet(bullet);
            }
        }

        public void SpawnBullet(BulletArgs args)
        {
            var bullet = _bulletSpawner.SpawnBullet();

            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.SetDamage(args.damage);
            bullet.SetOwner(args.isPlayer);
            bullet.SetVelocity(args.velocity);

            if (_activeBullets.Add(bullet))
                bullet.OnCollisionEntered += OnBulletCollision;
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                _bulletSpawner.UnspawnBullet(bullet);
            }
        }

        public void FixedTick()
        {
            CheckOutsideBounds();
        }
    }
}