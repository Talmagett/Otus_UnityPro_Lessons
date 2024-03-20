using Data.Variable;
using Entity;
using Entity.Components;
using UnityEngine;
using Zenject;

namespace Systems
{
    public class GameRules : MonoBehaviour
    {
        public AtomicVariable<bool> isGameOver;
        private CharacterEntity _characterEntity;

        private IComponent_Health _componentHealth;

        private void Start()
        {
            _characterEntity.TryComponent(out _componentHealth);
        }

        public void Update()
        {
            if (isGameOver.Value || _componentHealth.GetHealth() > 0) return;

            isGameOver.Value = true;
            Debug.Log("GameOver");
            Time.timeScale = 0;
        }

        [Inject]
        public void Construct(CharacterEntity characterEntity)
        {
            _characterEntity = characterEntity;
        }
    }
}