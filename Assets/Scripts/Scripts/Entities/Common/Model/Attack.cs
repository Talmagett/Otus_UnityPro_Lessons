using System;
using Lessons.Entities.Config;
using Lessons.Utils;

namespace Lessons.Entities.Common.Model
{
    [Serializable]
    public sealed class Attack
    {
        public AtomicVariable<Ability> weapon;
    }
}