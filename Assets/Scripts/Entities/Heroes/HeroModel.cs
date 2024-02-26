using Entities.Config;
using UnityEngine;

namespace Entities.Heroes
{
    public class HeroModel : MonoBehaviour
    {
        [field:SerializeField] public Hero HeroConfig { get; private set; }  
    }
}