using Entity;
using Entity.Components;
using TMPro;
using UnityEngine;
using Zenject;

namespace Visual.UI
{
    public class CharacterAmmoView : MonoBehaviour
    {
        [SerializeField] private string bulletsCountTextString;
        [SerializeField] private TMP_Text bulletsCountText;
        [SerializeField] private CharacterEntity character;

        private IComponent_Ammo _ammo;

        public void Start()
        {
            character.TryComponent(out _ammo);
            _ammo.OnCountChanged += UpdateText;
            UpdateText(_ammo.GetBulletsCount());
        }

        private void OnDestroy()
        {
            _ammo.OnCountChanged -= UpdateText;
        }

        private void UpdateText(int count)
        {
            bulletsCountText.text = $"{bulletsCountTextString} {count}/{_ammo.GetBulletsMaxCount()}";
        }
    }
}