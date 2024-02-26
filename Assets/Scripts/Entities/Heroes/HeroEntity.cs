using System;
using Entities.Common.Components;
using Modules.Entities.Scripts.MonoBehaviours;

namespace Entities.Heroes
{
    public class HeroEntity : MonoEntityBase
    {
        public static event Action<HeroEntity> CardClickPerformed;
        private void Awake()
        {
            var model = GetComponent<HeroModel>();
            Add(new AttackDamage{Value = model.HeroConfig.AttackDamage});
            Add(new Health(){Value = model.HeroConfig.Health});
            //Add(new AttackDamage{Value = model.HeroConfig.Ability});
        }

        private void OnMouseDown()
        {
            CardClickPerformed?.Invoke(this);
            print("lll");
        }
    }
}