using UnityEngine;

namespace GameSystems
{
    public sealed class FireInput : MonoBehaviour
    {
        public bool IsFirePressDown()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}