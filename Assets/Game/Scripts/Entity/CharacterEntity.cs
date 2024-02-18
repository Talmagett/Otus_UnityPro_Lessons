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
            Add(new Component_Health(character.HitPoints));
            
            Add(new Component_Move(character.Moved));
            Add(new Component_Position(transform));
            Add(new Component_Rotation(character.Rotated));
            Add(new Component_Shoot(character.FireEvent));
        }
    }
}