using Model;
using UnityEngine;

namespace Visual
{
    public class CharacterVisual : MonoBehaviour
    {
        //Data
        [SerializeField] private Character character;
        [SerializeField] private Animator animator;
        
        //Logic
        private CharacterAnimatorController _characterAnimatorController;
        
        private void Awake()
        {
            _characterAnimatorController = new CharacterAnimatorController(character.Moved, character.IsDead, animator, character.FireRequest);
        }
        
        private void OnEnable()
        {
            _characterAnimatorController.OnEnable();
        }
        
        private void OnDisable()
        {
            _characterAnimatorController.OnDisable();
        }
        
        public void Update()
        {
            _characterAnimatorController.Update();
        }
    }
}