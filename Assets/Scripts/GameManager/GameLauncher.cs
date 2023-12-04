using System.Collections;
using UnityEngine;
using Zenject;

namespace GameManager
{
    public class GameLauncher : MonoBehaviour
    {
        [SerializeField] private int delay;

        private GameManager _gameManager;
        
        [Inject]
        public void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void StartGame()
        {
            StartCoroutine(CountDown());
        }

        private IEnumerator CountDown()
        {
            while (delay > 0)
            {
                print(delay);
                yield return new WaitForSeconds(1);
                delay--;
            }

            print("Start");
            _gameManager.StartGame();
        }
    }
}