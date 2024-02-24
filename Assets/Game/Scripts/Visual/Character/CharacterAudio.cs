using UnityEngine;

namespace Visual.Character
{
    public class CharacterAudio : MonoBehaviour
    {
        [SerializeField] private Model.Character character;
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioClip damageAudio;

        private void OnEnable()
        {
            character.TakeDamage.Subscribe(OnTakeDamage);
        }

        private void OnDisable()
        {
            character.TakeDamage.Unsubscribe(OnTakeDamage);
        }

        private void OnTakeDamage(int obj)
        {
            audioSource.clip = damageAudio;
            audioSource.Play();
        }
    }
}