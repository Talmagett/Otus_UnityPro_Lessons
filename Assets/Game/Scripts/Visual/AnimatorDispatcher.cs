using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

namespace Lessons.Lesson15_VisualMechanics.Visual
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