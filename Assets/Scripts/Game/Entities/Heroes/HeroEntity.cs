using System;
using Game.Entities.Common.Components;
using Modules.Entities.Scripts.MonoBehaviours;

namespace Game.Entities.Heroes
{
    public class HeroEntity : MonoEntityBase
    {
        private void Awake()
        {
            var model = GetComponent<HeroModel>();
            Add(new AttackDamage { Value = model.HeroConfig.AttackDamage });
            Add(new Health { Value = model.HeroConfig.Health });
            //Add(new AttackDamage{Value = model.HeroConfig.Ability});
        }

        private void OnMouseDown()
        {
            CardClickPerformed?.Invoke(this);
            print("lll");
        }

        public static event Action<HeroEntity> CardClickPerformed;
    }
}