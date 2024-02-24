using UnityEngine;

namespace Visual.Zombie
{
    public class ZombieVisual : MonoBehaviour
    {
        //Data
        [SerializeField] private Model.Zombie character;
        [SerializeField] private Animator animator;

        //Logic
        private ZombieAnimatorController _zombieAnimatorController;

        private void Awake()
        {
            _zombieAnimatorController = new ZombieAnimatorController(character.IsDead, animator, character.AttackEvent);
        }

        public void Update()
        {
            _zombieAnimatorController.Update();
        }

        private void OnEnable()
        {
            _zombieAnimatorController.OnEnable();
        }

        private void OnDisable()
        {
            _zombieAnimatorController.OnDisable();
        }
    }
}