using System;
using UnityEngine;

namespace GameEngine
{
    [Serializable]
    public struct UnitData
    {
        [SerializeField] public string type;

        [SerializeField] public int hitPoints;

        [SerializeField] public Vector3 position;

        [SerializeField] public Vector3 rotation;
    }
}