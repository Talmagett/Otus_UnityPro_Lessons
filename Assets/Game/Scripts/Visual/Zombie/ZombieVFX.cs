using Entity;
using UnityEngine;

namespace Visual.Zombie
{
    public class ZombieVFX : MonoBehaviour
    {
        [SerializeField] private Model.Zombie zombie;

        [SerializeField] private VFXAutoDestroy deathVfx;

        private void OnEnable()
        {
            zombie.Life.DeathEvent.Subscribe(OnAttack);
        }

        private void OnDisable()
        {
            zombie.Life.DeathEvent.Unsubscribe(OnAttack);
        }

        private void OnAttack()
        {
            deathVfx.Play();
        }
    }
}