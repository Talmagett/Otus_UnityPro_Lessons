using System;
using UnityEngine;

namespace EcsEngine.Components.Transform
{
    [Serializable]
    public struct Rotation
    {
        public Quaternion value;
    }
}