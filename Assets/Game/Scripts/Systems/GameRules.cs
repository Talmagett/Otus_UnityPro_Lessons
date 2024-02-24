using Entity;
using Entity.Components;
using UnityEngine;

namespace Systems
{
    public class GameRules : MonoBehaviour
    {
        [SerializeField] private CharacterEntity characterEntity;
        private IComponent_Health _componentHealth;
        private bool _isGameOver;

        private void Start()
        {
            characterEntity.TryComponent(out _componentHealth);
        }

        public void Update()
        {
            if (_isGameOver || _componentHealth.GetHealth() > 0) return;

            _isGameOver = true;
            Debug.Log("GameOver");
            Time.timeScale = 0;
        }
    }
}