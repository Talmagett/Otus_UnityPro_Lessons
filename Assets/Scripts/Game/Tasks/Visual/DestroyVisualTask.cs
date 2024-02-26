using DG.Tweening;
using Game.Entities.Common.Components;
using Modules.Entities.Scripts;
using UnityEngine;

namespace Game.Tasks.Visual
{
    public sealed class DestroyVisualTask : VisualTask
    {
        private readonly float _duration;

        private readonly TransformComponent _transform;

        public DestroyVisualTask(IEntity entity, float duration)
        {
            _transform = entity.Get<TransformComponent>();
            _duration = duration;
        }

        public override bool Sticky { get; protected set; } = false;

        protected override void OnRun()
        {
            _transform.Value.DOScale(Vector3.zero, _duration).OnComplete(Finish);
        }
    }
}