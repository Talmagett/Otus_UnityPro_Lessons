using GameManager;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterDeathObserver:MonoBehaviour,IGameStartListener,IGameFinishListener,IGamePauseListener,IGameResumeListener
    {
        [SerializeField] private GameManager.GameManager gameManager;
        [SerializeField] private HitPointsComponent hitPointsComponent;

        private void OnCharacterDeath(GameObject _)
        {
            gameManager.FinishGame();
        }

        public void OnGameStart()
        {
            hitPointsComponent.OnHitPointsEmpty += OnCharacterDeath;
        }

        public void OnGameFinish()
        {
            hitPointsComponent.OnHitPointsEmpty -= OnCharacterDeath;
        }

        public void OnGamePause()
        {
            hitPointsComponent.OnHitPointsEmpty -= OnCharacterDeath;
        }

        public void OnGameResume()
        {
            hitPointsComponent.OnHitPointsEmpty += OnCharacterDeath;
        }
    }
}