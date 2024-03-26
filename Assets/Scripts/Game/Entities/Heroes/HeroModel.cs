using System.Linq;
using Game.Entities.Common.Components;
using Game.Entities.Config;
using Game.TurnSystem;
using Game.TurnSystem.Events;
using Game.TurnSystem.Events.Effect;
using Game.UI;
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
            
            foreach (var effect in heroConfig.Ability.Effects)
            {
                Add(effect);
            }
        }

        public virtual void Attack(EventBus eventBus, HeroPresenter target)
        {
            var damage = Get<AttackDamage>();
            eventBus.RaiseEvent(new DealDamageEvent(target.HeroModel, damage.Value));
        }

        public virtual void CounterAttack(EventBus eventBus, HeroPresenter target)
        {
            if (target.HeroModel.TryGet(out HunterEvadeEffectEvent hunterEvadeEffect))
            {
                return;
            }
            if (target.HeroModel.TryGet(out DivineShieldEffectEvent divineShieldEffect))
            {
                Remove(divineShieldEffect);
            }

            var damage = Get<AttackDamage>();
            eventBus.RaiseEvent(new DealDamageEvent(target.HeroModel, damage.Value));
        }
    }
}