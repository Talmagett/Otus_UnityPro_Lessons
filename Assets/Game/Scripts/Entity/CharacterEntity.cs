using Entity.Components;
using Model;
using UnityEngine;

namespace Entity
{
    public class CharacterEntity : Entity
    {
        [SerializeField] private Character character;

        private void Awake()
        {
            Add(new Component_Health(character.Life.HitPoints));
            Add(new Component_Damagable(character.Life.TakeDamage));
            Add(new Component_MoveEvent(character.Movement.MovedEvent));
            Add(new Component_Position(transform));
            Add(new Component_Rotation(character.RotatedEvent));
            Add(new Component_Shoot(character.Attack.AttackRequest));
            Add(new Component_AttackEvent(character.Attack.AttackEvent));
            Add(new Component_Ammo(character.BulletsData.Count, character.BulletsData.MaxCount));
        }
    }
}