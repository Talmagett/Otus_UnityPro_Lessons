using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    [System.Serializable]
    public class UIProvider : MonoBehaviour,IDisposable
    {
        [SerializeField] private Button pauseBtn;
        [SerializeField] private Button resumeBtn;

        private GameManager.GameManager _gameManager;
        
        [Inject]
        public void Construct(GameManager.GameManager gameManager)
        {
            _gameManager = gameManager;
            pauseBtn.onClick.AddListener(()=>_gameManager.PauseGame());
            resumeBtn.onClick.AddListener(()=>_gameManager.ResumeGame());
        }

        public void Dispose()
        {
            pauseBtn.onClick.RemoveAllListeners();
            resumeBtn.onClick.RemoveAllListeners();
        }
    }
}