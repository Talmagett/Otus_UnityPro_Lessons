using UnityEngine;

namespace GameSystems
{
    public sealed class MoveInput : MonoBehaviour
    {
        public Vector3 GetDirection()
        {
            var direction = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
                direction.z = 1;
            else if (Input.GetKey(KeyCode.S)) direction.z = -1;

            if (Input.GetKey(KeyCode.A))
                direction.x = -1;
            else if (Input.GetKey(KeyCode.D)) direction.x = 1;

            return direction;
        }
    }
}