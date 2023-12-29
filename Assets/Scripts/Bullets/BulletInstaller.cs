using Common;
using Level;
using UnityEngine;
using Zenject;

namespace Bullets
{
    public class BulletInstaller : MonoInstaller
    {
        [SerializeField] private LevelBounds levelBounds;
        [SerializeField] private PoolArgs<Bullet> bulletPoolArgs;

        public override void InstallBindings()
        {
            Container.Bind<BulletSpawner>()
                .AsSingle()
                .WithArguments(bulletPoolArgs)
                .NonLazy();
            Container.BindInterfacesAndSelfTo<BulletSystem>()
                .AsSingle()
                .WithArguments(levelBounds)
                .NonLazy();
        }
    }
}