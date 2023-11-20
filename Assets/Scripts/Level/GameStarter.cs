using System.Collections;
using UnityEngine;

namespace Level
{
    public class GameStarter:MonoBehaviour
    {
        [SerializeField] private int delay;
        [SerializeField] private GameManager.GameManager gameManager;
        
        public void StartGame()
        {
            StartCoroutine(CountDown());
        }

        private IEnumerator CountDown()
        {
            for (;delay >= 0; delay--)
            {
                yield return new WaitForSeconds(1);
                print(delay);
            }
            gameManager.StartGame();
        }
    }
}