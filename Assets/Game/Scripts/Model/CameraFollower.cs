using Entity.Components;
using UnityEngine;

namespace Model
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Entity.Entity entity;
        [SerializeField] private Vector3 followOffset;

        [SerializeField] private float followSpeed;

        private IComponent_Position _componentPosition;

        private void Start()
        {
            entity.TryComponent(out _componentPosition);
        }

        private void LateUpdate()
        {
            var targetPos = _componentPosition.GetPosition();
            targetPos.y = transform.position.y;
            targetPos += followOffset;
            transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        }
    }
}