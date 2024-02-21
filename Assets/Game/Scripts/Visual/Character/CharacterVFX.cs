using Model;
using UnityEngine;

namespace Visual
{
    public class CharacterVFX : MonoBehaviour
    {
        [SerializeField] private Character character;

        [SerializeField] private ParticleSystem shootVfx;
        [SerializeField] private ParticleSystem damageVfx;

        private void OnEnable()
        {
            character.FireEvent.Subscribe(OnFire);
            character.TakeDamage.Subscribe(OnTakeDamage);
        }

        private void OnDisable()
        {
            character.FireEvent.Unsubscribe(OnFire);
            character.TakeDamage.Unsubscribe(OnTakeDamage);
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