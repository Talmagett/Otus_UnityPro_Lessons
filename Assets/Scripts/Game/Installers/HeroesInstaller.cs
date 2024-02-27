using System;
using Game.Entities.Config;
using Game.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class HeroesInstaller : MonoInstaller
{
    [Header("Configs")] [SerializeField] private HeroesPack heroesPack;

    [Space] [SerializeField] private UIService uiService;
    [SerializeField] private HeroView heroViewPrefab;
    
    public override void InstallBindings()
    {
        Container.BindInstance(heroesPack).AsSingle();
        Container.BindInstance(uiService).AsSingle();
        Container.BindInstance(heroViewPrefab).AsSingle();
    }

    [System.Serializable]
    public class HeroesPack
    {
        [RequiredListLength(1,4)]
        public Hero[] bluePlayerHeroes;
        [RequiredListLength(1,4)]
        public Hero[] redPlayerHeroes;
    }
}