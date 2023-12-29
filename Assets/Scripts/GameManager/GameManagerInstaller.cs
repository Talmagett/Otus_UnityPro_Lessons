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
    public class GameManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
        }
    }
}