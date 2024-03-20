using UnityEngine;

namespace Visual.Character
{
    public class CharacterVFX : MonoBehaviour
    {
        [SerializeField] private Model.Character character;

        [SerializeField] private ParticleSystem shootVfx;
        [SerializeField] private ParticleSystem damageVfx;

        private void OnEnable()
        {
            character.Attack.AttackEvent.Subscribe(OnFire);
            character.Life.TakeDamage.Subscribe(OnTakeDamage);
        }

        private void OnDisable()
        {
            character.Attack.AttackEvent.Unsubscribe(OnFire);
            character.Life.TakeDamage.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int value)
        {
            damageVfx.Play();
        }

        private void OnFire()
        {
            shootVfx.transform.position = character.FirePoint.position;
            shootVfx.Play();
        }
    }
}