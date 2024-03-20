using Entity.Components;
using Model;
using UnityEngine;

namespace Entity
{
    public class ZombieEntity : Entity
    {
        [SerializeField] private Zombie zombie;

        private void Awake()
        {
            Add(new Component_Health(zombie.Life.HitPoints));
            Add(new Component_Damagable(zombie.Life.TakeDamage));
            Add(new Component_Position(transform));
        }
    }
}