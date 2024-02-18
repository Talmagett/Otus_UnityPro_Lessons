using Model;
using UnityEngine;

namespace Visual
{
    public class CharacterVFX : MonoBehaviour
    {
        [SerializeField] private Character _character;

        public ParticleSystem _shootVfx;
        public ParticleSystem _damageVfx;

        private void OnEnable()
        {
            _character.FireEvent.Subscribe(OnFire);
            _character.TakeDamage.Subscribe(OnTakeDamage);
        }

        private void OnDisable()
        {
            _character.FireEvent.Unsubscribe(OnFire);
            _character.TakeDamage.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int value)
        {
            _damageVfx.Play();
        }

        private void OnFire()
        {
            _shootVfx.transform.position = _character.FirePoint.position;
            _shootVfx.Play();
        }
    }
}