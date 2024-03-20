using System;
using Data.Variable;

namespace Entity.Components
{
    public class Component_Ammo : IComponent_Ammo, IDisposable
    {
        private readonly IAtomicVariable<int> _bulletsCount;
        private readonly IAtomicVariable<int> _bulletsMaxCount;

        public Component_Ammo(IAtomicVariable<int> characterBulletsCount, AtomicVariable<int> characterBulletsMaxCount)
        {
            _bulletsCount = characterBulletsCount;
            _bulletsMaxCount = characterBulletsMaxCount;
            _bulletsCount.ValueChanged += OnCountChangedInvoke;
        }

        public event Action<int> OnCountChanged;

        public int GetBulletsCount()
        {
            return _bulletsCount.Value;
        }

        public int GetBulletsMaxCount()
        {
            return _bulletsMaxCount.Value;
        }

        public void Dispose()
        {
            _bulletsCount.ValueChanged -= OnCountChangedInvoke;
        }

        private void OnCountChangedInvoke(int count)
        {
            OnCountChanged?.Invoke(count);
        }
    }
}