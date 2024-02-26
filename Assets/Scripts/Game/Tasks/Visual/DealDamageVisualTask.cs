using DG.Tweening;
using Game.Entities.Common.Components;
using Modules.Entities.Scripts;
using UnityEngine;

namespace Game.Tasks.Visual
{
    public sealed class DealDamageVisualTask : VisualTask
    {
        private readonly float _duration;

        private readonly TransformComponent _transform;

        public DealDamageVisualTask(IEntity entity, float duration)
        {
            _transform = entity.Get<TransformComponent>();
            _duration = duration;
        }

        public override bool Sticky { get; protected set; } = true;

        protected override void OnRun()
        {
            _transform.Value.DOPunchScale(Vector3.one * 1.3f, _duration, 5).OnComplete(Finish);
        }
    }
}