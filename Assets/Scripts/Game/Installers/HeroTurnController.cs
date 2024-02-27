using System;
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
        public HeroEntity CurrentHero => _heroes[_index];
        public event Action<IEntity> HeroClickPerformed;
        private int _index=0;
        private HeroEntity[] _heroes;
        
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
                _uiService.GetRedPlayer().AddView(view);
                var heroEntity = view.GetComponent<HeroEntity>();
                heroEntity.SetEntity(redHero,PlayerColor.Color.Red);
            }
            foreach (var blueHero in _heroesPack.bluePlayerHeroes)
            {
                var view =  GameObject.Instantiate(_heroView, _uiService.GetBluePlayer().transform);
                _uiService.GetBluePlayer().AddView(view);
                var heroEntity = view.GetComponent<HeroEntity>();
                heroEntity.SetEntity(blueHero,PlayerColor.Color.Blue);
            }

            var redPlayers = _uiService.GetRedPlayer().GetViews().ToArray();
            var bluePlayers = _uiService.GetBluePlayer().GetViews().ToArray();

            HeroView[] views = new HeroView[redPlayers.Length+bluePlayers.Length];
            
            for (int i = 0; i < views.Length; i++)
            {
                views[i] = (i % 2 == 0) ? redPlayers[i / 2] : bluePlayers[i / 2];
            }

            _uiService.GetRedPlayer().OnHeroClicked += OnHeroClicked;
            _uiService.GetBluePlayer().OnHeroClicked += OnHeroClicked;
            _heroes = views.Select(t => t.GetComponent<HeroEntity>()).ToArray();
        }

        private void OnHeroClicked(HeroView heroView)
        {
            if(heroView.TryGetComponent(out IEntity entity))
                HeroClickPerformed?.Invoke(entity);
        }

        public void NextHero()
        {
            _index++;
            if (_index >= _heroes.Length)
                _index = 0;
        }
    }
}