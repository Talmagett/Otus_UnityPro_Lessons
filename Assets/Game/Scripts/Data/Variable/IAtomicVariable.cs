using System;

namespace Data.Variable
{
    public interface IAtomicVariable<T> : IAtomicValue<T>
    {
        event Action<T> ValueChanged;
        new T Value { get; set; }
    }
}