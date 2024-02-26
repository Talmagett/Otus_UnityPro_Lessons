using DG.Tweening;
using Game.Entities.Common.Components;
using Modules.Entities.Scripts;
using UnityEngine;

namespace Game.Tasks.Visual
{
    public sealed class MoveVisualTask : VisualTask
    {
        private readonly float _duration;
        private readonly Vector3 _position;

        private readonly TransformComponent _transform;

        public MoveVisualTask(IEntity entity, Vector3 position, float duration, bool sticky = false)
        {
            _transform = entity.Get<TransformComponent>();
            _position = position;
            _duration = duration;

            Sticky = sticky;
        }

        public override bool Sticky { get; protected set; }

        protected override void OnRun()
        {
            _transform.Value.DOMove(_position, _duration).OnComplete(Finish);
        }
    }
}