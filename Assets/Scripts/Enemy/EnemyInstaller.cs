using Common;
using Components;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyInstaller:MonoInstaller
    {
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private HitPointsComponent character;
        [SerializeField] private PoolArgs<Enemy> enemyPoolArgs;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemySpawner>()
                .AsSingle()
                .WithArguments(enemyPositions,character,enemyPoolArgs)
                .NonLazy();
            //fabric installer
            Container.Bind<EnemyManager>().AsSingle().NonLazy();
            Container.Bind<EnemyCountdownSpawner>().AsSingle().NonLazy();
        }
    }
}