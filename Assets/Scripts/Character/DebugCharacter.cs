using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Sample
{
    public class DebugCharacter : MonoBehaviour
    {
        private Character _character;

        [Inject]
        public void Construct(Character character)
        {
            _character = character;
        }

        [Button]
        public void GetStats()
        {
            Debug.ClearDeveloperConsole();
            foreach (var (key, value) in _character.GetStats())
            {
                print($"{key} : {value}");
            }
        }
    }
}