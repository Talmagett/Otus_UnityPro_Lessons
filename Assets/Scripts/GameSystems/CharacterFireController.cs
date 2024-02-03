using EcsEngine.Components.Attack;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace GameSystems
{
    public sealed class CharacterFireController : MonoBehaviour
    {
        [SerializeField]
        private Entity character;

        [SerializeField]
        private FireInput fireInput;

        private void Update()
        {
            if (this.fireInput.IsFirePressDown())
            {
                this.character.SetData(new FireRequest());
            }
        }
    }
}