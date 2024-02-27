using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(Canvas))]
    public sealed class HeroListView : MonoBehaviour
    {
        public event Action<HeroView> OnHeroClicked;
        
        private const int FORWARD_LAYER = 10;
        private const int BACK_LAYER = 0;

        private List<HeroView> _views=new ();

        private Canvas canvas;

        private void Awake()
        {
            canvas = GetComponent<Canvas>();
        }

        private void OnDestroy()
        {
            var @event = OnHeroClicked;
            if (@event == null) return;

            foreach (var @delegate in @event.GetInvocationList()) OnHeroClicked -= (Action<HeroView>)@delegate;
        }

        public IReadOnlyList<HeroView> GetViews()
        {
            return _views;
        }

        public HeroView GetView(int index)
        {
            return _views[index];
        }

        public void AddView(HeroView heroView)
        {
            _views.Add(heroView);
            heroView.OnClicked += () => OnHeroClicked?.Invoke(heroView);
        }
        
        public void SetActive(bool isActive)
        {
            canvas.sortingOrder = isActive ? FORWARD_LAYER : BACK_LAYER;
        }
    }
}