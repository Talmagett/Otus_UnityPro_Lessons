using Components;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyInstaller:MonoInstaller
    {
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private HitPointsComponent character;
        [SerializeField] private Transform poolParent;
        [SerializeField] private Transform worldParent;
        [SerializeField] private Enemy prefab;
        public override void InstallBindings()
        {
            Container.Bind<EnemySpawner>()
                .AsCached()
                .WithArguments(enemyPositions,character,poolParent,worldParent,prefab)
                .NonLazy();
            Container.Bind<EnemyManager>().AsSingle().NonLazy();
            Container.Bind<EnemyCountdownSpawner>().AsCached().NonLazy();
        }
    }
}