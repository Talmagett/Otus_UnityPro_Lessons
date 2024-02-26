using System;
using Game.Entities.Config;
using Game.UI;
using UnityEngine;
using Zenject;

public class HeroesInstaller : MonoInstaller
{
    [Header("Configs")] [SerializeField] private HeroesPack heroesPack;

    [Space] [SerializeField] private UIService uiService;

    public override void InstallBindings()
    {
        Container.BindInstance(heroesPack).AsSingle();
        Container.BindInstance(uiService).AsSingle();
    }

    [Serializable]
    public class HeroesPack
    {
        public Hero[] bluePlayerHeroes;
        public Hero[] redPlayerHeroes;
    }
}