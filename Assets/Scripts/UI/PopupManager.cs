using System;
using System.Collections.Generic;

namespace UI
{
    public class PopupManager
    {
        private readonly Dictionary<Type, IPopup> _popups = new Dictionary<Type, IPopup>();

        public void AddPopup(IPopup popup)
        {
            _popups.Add(popup.GetType(),popup);
        }

        public void ShowPopup(Type type,params object[] args)
        {
            if (!_popups.ContainsKey(type))
                throw new NullReferenceException("No popup with this type");
            
            _popups[type].Show(args);
        }
    }

    public interface IPopup
    {
        void Hide();
        void Show(params object[] args);
    }
}