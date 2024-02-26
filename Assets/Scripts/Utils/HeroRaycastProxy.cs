using System;
using Entities.Heroes;
using UnityEngine;

namespace Utils
{
    public class HeroRaycastProxy : MonoBehaviour
    {
        public HeroEntity HeroEntity { get;private set; }

        private void Awake()
        {
            HeroEntity = GetComponentInParent<HeroEntity>();
        }
    }
}