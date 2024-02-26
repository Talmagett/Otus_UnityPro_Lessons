using System;
using Zenject;

namespace Game.TurnSystem.Handlers
{
    public abstract class BaseHandler<T> : IInitializable, IDisposable
    {
        protected BaseHandler(EventBus eventBus)
        {
            EventBus = eventBus;
        }

        protected EventBus EventBus { get; }

        void IDisposable.Dispose()
        {
            EventBus.Unsubscribe<T>(HandleEvent);
        }

        void IInitializable.Initialize()
        {
            EventBus.Subscribe<T>(HandleEvent);
        }

        protected abstract void HandleEvent(T evt);
    }
}