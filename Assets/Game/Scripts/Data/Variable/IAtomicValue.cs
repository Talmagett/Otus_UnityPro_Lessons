using System;

namespace Data.Variable
{
    public interface IAtomicValue<T>
    {
        T Value { get; }
    }

    public class AtomicValue<T> : IAtomicValue<T>
    {
        private readonly Func<T> _function;

        public AtomicValue(Func<T> function)
        {
            _function = function;
        }

        public T Value => _function.Invoke();
    }
}