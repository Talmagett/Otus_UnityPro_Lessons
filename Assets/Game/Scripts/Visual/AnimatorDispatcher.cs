using UnityEngine;

namespace Visual
{
    public class AnimatorDispatcher : MonoBehaviour
    {
        [SerializeField] private Model.Character character;

        public void ReceiveEvent(string value)
        {
            if (value == "shoot") character.FireEvent.Invoke();
        }
    }
}