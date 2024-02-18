using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

namespace Lessons.Lesson15_VisualMechanics.Visual
{
    public class CharacterAudio : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private AudioSource _audioSource;
        
        public AudioClip _damageAudio;

        private void OnEnable()
        {
            _character.TakeDamage.Subscribe(OnTakeDamage);
        }

        private void OnDisable()
        {
            _character.TakeDamage.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int obj)
        {
            _audioSource.clip = _damageAudio;
            _audioSource.Play();
        }
    }
}