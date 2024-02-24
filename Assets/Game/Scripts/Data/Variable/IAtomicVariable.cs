using System;

namespace Data.Variable
{
    public interface IAtomicVariable<T> : IAtomicValue<T>
    {
        new T Value { get; set; }
        event Action<T> ValueChanged;
    }
}