using UnityEngine;

//Менять нельзя!
namespace Audio
{
    public sealed class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource soundSource;

        public static AudioPlayer Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void PlaySound(AudioClip sound)
        {
            soundSource.PlayOneShot(sound);
        }
    }
}