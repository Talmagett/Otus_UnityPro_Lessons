using System;

namespace Lessons.Lesson14_ModuleMechanics
{
    public interface IAtomicFunction<out T>
    {
        T GetResult();
    }

    class AtomicFunction<T> : IAtomicFunction<T>
    {
        private readonly Func<T> _function;

        public AtomicFunction(Func<T> function)
        {
            _function = function;
        }

        public T GetResult()
        {
            return _function.Invoke();
        }
    }
}