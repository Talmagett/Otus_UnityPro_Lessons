using System;

namespace Entity.Components
{
    public interface IComponent_Ammo
    {
        int GetBulletsCount();
        int GetBulletsMaxCount();
        event Action<int> OnCountChanged;
    }
}