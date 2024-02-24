using Entity;
using Entity.Components;
using TMPro;
using UnityEngine;

namespace Visual.UI
{
    public class CharacterHealthView : MonoBehaviour
    {
        [SerializeField] private CharacterEntity character;
        [SerializeField] private string healthTextString;

        [SerializeField] private TMP_Text healthText;

        private IComponent_Health _health;

        private void Start()
        {
            character.TryComponent(out _health);
            _health.OnHealthChanged += UpdateText;
            UpdateText(_health.GetHealth());
        }

        private void OnDestroy()
        {
            _health.OnHealthChanged -= UpdateText;
        }

        private void UpdateText(int health)
        {
            healthText.text = $"{healthTextString} {health}";
        }
    }
}