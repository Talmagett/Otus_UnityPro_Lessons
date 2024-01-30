using System;
using System.Collections.Generic;

namespace GameEngine
{
    public class GameContext
    {
        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();
        public TService GetService<TService>()
        {
            if(_services.ContainsKey(typeof(TService)))
            {
                return (TService)_services[typeof(TService)];
            }

            throw new NullReferenceException($"No such service");
        }
    }
}