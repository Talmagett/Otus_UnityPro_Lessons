using Bullets;
using Character;
using Components;
using Enemy;
using Input;
using Level;
using UI;
using UnityEngine;
using Zenject;

namespace GameManager
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject characterGameObject;
        [SerializeField] private BulletInstaller bulletInstaller;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
            
            PlayerBinding();
            bulletInstaller.InstallBindings(Container);
        }

        private void PlayerBinding()
        {
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();

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