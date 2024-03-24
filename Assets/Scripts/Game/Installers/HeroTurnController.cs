using System;
using System.Collections.Generic;
using System.Linq;
using Game.Entities.Common.Components;
using Game.Entities.Heroes;
using Game.UI;
using Modules.Entities.Scripts;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class HeroTurnController : IInitializable
    {
        public HeroPresenter CurrentHero;
        public event Action<HeroPresenter> TargetHeroClickPerformed;
        private List<HeroPresenter> _heroes = new List<HeroPresenter>();
        private Queue<HeroPresenter> _queuedHeroes = new Queue<HeroPresenter>();
        private bool _isRedTurn;
        private HeroesInstaller.HeroesPack _heroesPack;
        private UIService _uiService;
        private HeroView _heroView;
        
        public HeroTurnController(HeroesInstaller.HeroesPack heroesPack, UIService uiService,HeroView heroView)
        {
            _heroesPack = heroesPack;
            _uiService = uiService;
            _heroView = heroView;
        }

        void IInitializable.Initialize()
        {
            foreach (var redHero in _heroesPack.redPlayerHeroes)
            {
                var view =  GameObject.Instantiate(_heroView, _uiService.GetRedPlayer().transform);
                view.SetIcon(redHero.Icon);
                _uiService.GetRedPlayer().AddView(view);
                var hero = new HeroModel(redHero, PlayerColor.Color.Red);
                var heroPresenter = new HeroPresenter(hero,view);
                _heroes.Add(heroPresenter);
            }
            
            foreach (var blueHero in _heroesPack.bluePlayerHeroes)
            {
                var view =  GameObject.Instantiate(_heroView, _uiService.GetBluePlayer().transform);
                view.SetIcon(blueHero.Icon);
                _uiService.GetBluePlayer().AddView(view);
                var hero = new HeroModel(blueHero,PlayerColor.Color.Blue);
                var heroPresenter = new HeroPresenter(hero,view);
                _heroes.Add(heroPresenter);
            }

            for (var i = 0; i < _heroes.Count; i++)
            {
                _queuedHeroes.Enqueue(i % 2 == 0
                    ? _heroes[i / 2]
                    : _heroes[i / 2 + _heroesPack.redPlayerHeroes.Length]);
            }

            _uiService.GetRedPlayer().OnHeroClicked += OnHeroClicked;
            _uiService.GetBluePlayer().OnHeroClicked += OnHeroClicked;
            
            NextHero();
        }

        
        private void OnHeroClicked(HeroView heroView)
        {
            var heroPresenter = _heroes.FirstOrDefault(t => t.HeroView == heroView);
            TargetHeroClickPerformed?.Invoke(heroPresenter);
        }

        public void NextHero()
        {
            if (CurrentHero != null)
            {
                CurrentHero.HeroView.SetActive(false);
                _queuedHeroes.Enqueue(CurrentHero);
            }
            CurrentHero = _queuedHeroes.Dequeue();
            CurrentHero.HeroView.SetActive(true);
        }

        public void DestroyHero(HeroPresenter presenter)
        {
            GameObject.Destroy(presenter.HeroView.gameObject);
            _heroes.Remove(presenter);
        }
    }
}