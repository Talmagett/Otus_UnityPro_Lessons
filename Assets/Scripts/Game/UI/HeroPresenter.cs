using System;
using Game.Entities.Common.Components;
using Game.Entities.Config;
using Game.Entities.Heroes;
using UnityEngine;

namespace Game.UI
{
    public class HeroPresenter
    {
        public readonly HeroModel HeroModel;
        public readonly HeroView HeroView;
        
        public HeroPresenter(HeroModel heroModel, HeroView heroView)
        {
            HeroModel = heroModel;
            HeroView = heroView;
            HeroModel.Add(this);
            UpdateView();
        }

        public void UpdateView()
        {
            var attackDamage = HeroModel.Get<AttackDamage>();
            var health = HeroModel.Get<Health>();
            HeroView.SetStats($"{attackDamage.Value}/{health.Value}");
        }
    }
}