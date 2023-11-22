using UnityEngine;

namespace ShootEmUp
{
    public class CharacterDeathObserver:MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private HitPointsComponent hitPointsComponent;

        private void OnEnable()
        {
            hitPointsComponent.OnHitPointsEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            hitPointsComponent.OnHitPointsEmpty -= OnCharacterDeath;
        }
        
        private void OnCharacterDeath(GameObject _)
        {
            gameManager.FinishGame();
        }
    }
}