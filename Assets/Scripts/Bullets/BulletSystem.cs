using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private LevelBounds levelBounds;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();

        private void FixedUpdate()
        {
            CheckOutsideBounds();
        }

        private void CheckOutsideBounds()
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!levelBounds.InBounds(bullet.transform.position)) 
                    RemoveBullet(bullet);
            }
        }

        public void SpawnBullet(Args args)
        {
            var bullet = bulletSpawner.SpawnBullet();

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
            DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bulletSpawner.UnspawnBullet(bullet);
            }
        }
        
        private void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent team)) return;

            if (bullet.IsPlayer == team.IsPlayer) return;

            if (other.TryGetComponent(out HitPointsComponent hitPoints)) hitPoints.TakeDamage(bullet.Damage);
        }

        public struct Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}