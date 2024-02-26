using Game.Entities.Config;
using UnityEngine;

namespace Game.Entities.Heroes
{
    public class HeroModel : MonoBehaviour
    {
        [field:SerializeField] public Hero HeroConfig { get; private set; }  
    }
}