using System;

namespace Entity.Components
{
    public interface IComponent_Health
    {
        int GetHealth();
        event Action<int> OnHealthChanged;
    }
}