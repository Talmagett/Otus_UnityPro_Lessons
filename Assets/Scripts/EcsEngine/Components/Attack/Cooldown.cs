using System;

namespace EcsEngine.Components.Attack
{
    [Serializable]
    public struct Cooldown
    {
        public float maxValue;
        public float value;
        public bool canUse => value <= 0;
    }
}