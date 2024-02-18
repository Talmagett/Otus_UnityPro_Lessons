using System;

namespace Lessons.Lesson14_ModuleMechanics
{
    public interface IAtomicAction
    {
        void Invoke();
    }
    
    public interface IAtomicAction<in T>
    {
        void Invoke(T value);
    }
}