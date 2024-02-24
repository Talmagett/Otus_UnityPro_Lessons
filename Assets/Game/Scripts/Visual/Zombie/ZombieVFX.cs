using UnityEngine;

namespace Visual.Zombie
{
    public class ZombieVFX : MonoBehaviour
    {
        [SerializeField] private Model.Zombie zombie;

        [SerializeField] private ParticleSystem attackVfx;

        private void OnEnable()
        {
            zombie.Death.Subscribe(OnAttack);
        }

        private void OnDisable()
        {
            zombie.Death.Unsubscribe(OnAttack);
        }

        private void OnAttack()
        {
            attackVfx.Play();
        }
    }
}