using System;
using Game.Entities.Common.Components;
using Game.Entities.Config;
using Game.UI;
using Modules.Entities.Scripts.MonoBehaviours;
using UnityEngine;

namespace Game.Entities.Heroes
{
    [RequireComponent(typeof(HeroView))]
    public class HeroEntity : MonoEntityBase
    {
        private HeroView _heroView;
        public void SetEntity(Hero heroConfig, PlayerColor.Color playerColor)
        {
            Add(new AttackDamage { Value = heroConfig.AttackDamage });
            Add(new Health { Value = heroConfig.Health });
            Add(new PlayerColor{Value = playerColor});

            _heroView = GetComponent<HeroView>();
            SetView(heroConfig);
        }

        private void SetView(Hero heroConfig)
        {
            _heroView.SetIcon(heroConfig.Icon);
            _heroView.SetStats($"{heroConfig.AttackDamage}/{heroConfig.Health}");
        }
    }
}