using UnityEngine;

namespace Entity
{
    public class VFXAutoDestroy : MonoBehaviour
    {
        [SerializeField] private float delay=2;

        [SerializeField] private ParticleSystem particle;

        public void Play()
        {
            transform.parent = null;
            particle.Play();
            Destroy(gameObject,delay);
        }
    }
}