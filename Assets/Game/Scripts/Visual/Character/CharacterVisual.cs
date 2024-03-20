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
                new CharacterAnimatorController(character.Movement.MoveDirection, character.Life.IsDead,character.Life.TakeDamage, animator, character.Attack.AttackRequest);
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