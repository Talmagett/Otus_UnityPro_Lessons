using Model;
using UnityEngine;

namespace Visual
{
    public class ZombieVisual : MonoBehaviour
    {
        //Data
        [SerializeField] private Zombie character;
        [SerializeField] private Animator animator;
        
        //Logic
        private ZombieAnimatorController _zombieAnimatorController;
        
        private void Awake()
        {
            _zombieAnimatorController = new ZombieAnimatorController(character.IsDead, animator, character.AttackEvent);
        }
        
        private void OnEnable()
        {
            _zombieAnimatorController.OnEnable();
        }
        
        private void OnDisable()
        {
            _zombieAnimatorController.OnDisable();
        }
        
        public void Update()
        {
            _zombieAnimatorController.Update();
        }
    }
}