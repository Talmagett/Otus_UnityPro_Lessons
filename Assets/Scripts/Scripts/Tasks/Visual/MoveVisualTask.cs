using DG.Tweening;
using Entities;
using Lessons.Entities.Common.Components;
using UnityEngine;

namespace Lessons.Tasks.Visual
{
    public sealed class MoveVisualTask : VisualTask
    {
        public override bool Sticky { get; protected set; }

        private readonly TransformComponent _transform;
        private readonly Vector3 _position;
        private readonly float _duration;
        
        public MoveVisualTask(IEntity entity, Vector3 position, float duration, bool sticky = false)
        {
            _transform = entity.Get<TransformComponent>();
            _position = position;
            _duration = duration;

            Sticky = sticky;
        }
        
        protected override void OnRun()
        {
            _transform.Value.DOMove(_position, _duration).OnComplete(Finish);
        }
    }
}