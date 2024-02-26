using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    [RequireComponent(typeof(Canvas))]
    public sealed class HeroListView : MonoBehaviour
    {
        private const int FORWARD_LAYER = 10;
        private const int BACK_LAYER = 0;

        [SerializeField] private HeroView[] views;

        private Canvas canvas;

        private void Awake()
        {
            canvas = GetComponent<Canvas>();
        }

        private void OnEnable()
        {
            foreach (var view in views) view.OnClicked += () => OnHeroClicked?.Invoke(view);
        }

        private void OnDisable()
        {
            var @event = OnHeroClicked;
            if (@event == null) return;

            foreach (var @delegate in @event.GetInvocationList()) OnHeroClicked -= (Action<HeroView>)@delegate;
        }

        public event Action<HeroView> OnHeroClicked;

        public IReadOnlyList<HeroView> GetViews()
        {
            return views;
        }

        public HeroView GetView(int index)
        {
            return views[index];
        }

        public void SetActive(bool isActive)
        {
            canvas.sortingOrder = isActive ? FORWARD_LAYER : BACK_LAYER;
        }
    }
}