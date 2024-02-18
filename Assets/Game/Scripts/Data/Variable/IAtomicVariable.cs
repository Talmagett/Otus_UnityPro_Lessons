using System;

namespace Lessons.Lesson14_ModuleMechanics
{
    public interface IAtomicVariable<T> : IAtomicValue<T>
    {
        event Action<T> ValueChanged;
        new T Value { get; set; }
    }
}