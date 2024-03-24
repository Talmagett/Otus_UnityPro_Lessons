using DG.Tweening;
using Game.Entities.Common.Components;
using Game.UI;
using Modules.Entities.Scripts;
using UnityEngine;

namespace Game.Tasks.Visual
{
    public sealed class DealDamageVisualTask : VisualTask
    {
        private readonly HeroPresenter _heroPresenter;
        public DealDamageVisualTask(IEntity entity)
        {
            entity.TryGet(out _heroPresenter);
        }

        public override bool Sticky { get; protected set; } = true;

        protected override void OnRun()
        {
            _heroPresenter.UpdateView();
            Finish();
        }
    }
}