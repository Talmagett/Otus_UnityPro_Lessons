using System;
using Data.Variable;
using Systems;
using UnityEngine;

namespace Visual.UI
{
    public class GameOverListener : MonoBehaviour
    {
        public AtomicVariable<GameRules> gameRules;
        public AtomicVariable<GameObject> gameOverPanel;
            
        private void OnEnable()
        {
            gameRules.Value.isGameOver.ValueChanged += SetVisible;
        }

        private void OnDisable()
        {
            gameRules.Value.isGameOver.ValueChanged -= SetVisible;
        }

        private void SetVisible(bool state)
        {
            gameOverPanel.Value.SetActive(state);
        }
    }
}