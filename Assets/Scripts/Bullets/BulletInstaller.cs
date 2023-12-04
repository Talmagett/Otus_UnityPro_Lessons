using Level;
using UnityEngine;
using Zenject;

namespace Bullets
{
    [System.Serializable]
    public class BulletInstaller
    {
        [SerializeField] private LevelBounds levelBounds;
        [SerializeField] private Transform poolTransform;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private Bullet bulletPrefab;
        public void InstallBindings(DiContainer container)
        {
            container.Bind<BulletSpawner>()
                .AsSingle()
                .WithArguments(poolTransform,worldTransform,bulletPrefab)
                .NonLazy();
            container.BindInterfacesAndSelfTo<BulletSystem>()
                .AsSingle()
                .WithArguments(levelBounds)
                .NonLazy();
            
        }
    }
}