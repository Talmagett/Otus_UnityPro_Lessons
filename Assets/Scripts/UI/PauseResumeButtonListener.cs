using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class PauseResumeButtonListener : MonoBehaviour
    {
        [SerializeField] private Button pauseBtn;
        [SerializeField] private Button resumeBtn;

        private GameManager.GameManager _gameManager;

        [Inject]
        public void Construct(GameManager.GameManager gameManager)
        {
            _gameManager = gameManager;
            pauseBtn.onClick.AddListener(OnPauseClicked);
            resumeBtn.onClick.AddListener(OnResumeClicked);
        }

        public void OnDestroy()
        {
            pauseBtn.onClick.RemoveListener(OnPauseClicked);
            resumeBtn.onClick.RemoveListener(OnResumeClicked);
        }

        private void OnPauseClicked()
        {
            _gameManager.PauseGame();
        }

        private void OnResumeClicked()
        {
            _gameManager.ResumeGame();
        }
    }
}