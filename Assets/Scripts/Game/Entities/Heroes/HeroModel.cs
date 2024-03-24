using Game.Entities.Common.Components;
using Game.Entities.Config;
using Modules.Entities.Scripts.Base;

namespace Game.Entities.Heroes
{
    public class HeroModel : ListEntity
    {
        public HeroModel(HeroConfig heroConfig, PlayerColor.Color playerColor)
        {
            Add(new AttackDamage { Value = heroConfig.AttackDamage });
            Add(new Health { Value = heroConfig.Health });
            Add(new PlayerColor{Value = playerColor});
        }
    }
}