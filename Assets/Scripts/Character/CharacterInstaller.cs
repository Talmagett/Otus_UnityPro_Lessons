using Components;
using UnityEngine;
using Zenject;

namespace Character
{
    public class CharacterInstaller:MonoInstaller
    {
        [SerializeField] private GameObject characterGameObject;

        public override void InstallBindings()
        {
            Container.Bind<CharacterMoveController>()
                .AsCached()
                .WithArguments(characterGameObject.GetComponent<MoveComponent>())
                .NonLazy();
            
            Container.Bind<CharacterAttackController>()
                .AsCached()
                .WithArguments(characterGameObject.GetComponent<WeaponComponent>())
                .NonLazy();

            Container.Bind<CharacterDeathObserver>()
                .AsCached()
                .WithArguments(characterGameObject.GetComponent<HitPointsComponent>())
                .NonLazy();
        }
    }
}