using Model;
using UnityEngine;

namespace Visual
{
    public class AnimatorDispatcher : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        public void ReceiveEvent(string value)
        {
            if (value == "shoot")
            {
                _character.FireEvent.Invoke(); 
            }
        }
    }
}