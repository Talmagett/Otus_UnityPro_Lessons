using UnityEngine;

namespace Visual.Character
{
    public class CharacterVisual : MonoBehaviour
    {
        //Data
        [SerializeField] private Model.Character character;
        [SerializeField] private Animator animator;

        //Logic
        private CharacterAnimatorController _characterAnimatorController;

        private void Awake()
        {
            _characterAnimatorController =
                new CharacterAnimatorController(character.Moved, character.IsDead, animator, character.FireRequest);
        }

        public void Update()
        {
            _characterAnimatorController.Update();
        }

        private void OnEnable()
        {
            _characterAnimatorController.OnEnable();
        }

        private void OnDisable()
        {
            _characterAnimatorController.OnDisable();
        }
    }
}