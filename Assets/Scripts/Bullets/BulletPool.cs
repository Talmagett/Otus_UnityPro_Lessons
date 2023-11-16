namespace ShootEmUp
{
    public class BulletPool : PoolSystem<Bullet>
    {
        public Bullet SpawnBullet()
        {
            var bullet = GetInstance();

            if (bullet is not null)
                bullet.transform.SetParent(worldTransform);
            else
                bullet = Instantiate(prefab, worldTransform);
            return bullet;
        }

        public void UnspawnBullet(Bullet bullet)
        {
            bullet.transform.SetParent(container);
            Release(bullet);
        }
    }
}