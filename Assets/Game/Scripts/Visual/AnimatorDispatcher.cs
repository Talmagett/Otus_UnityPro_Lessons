using UnityEngine;

namespace Visual
{
    public class AnimatorDispatcher : MonoBehaviour
    {
        [SerializeField] private Character character;

        public void ReceiveEvent(string value)
        {
            if (value == "shoot") character.FireEvent.Invoke();
        }
    }
}