using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Variable
{
    [Serializable]
    [InlineProperty]
    public class AtomicVariable<T> : IAtomicVariable<T>
    {
        [HideLabel] [OnValueChanged("OnValueChangedInEditor")] [SerializeField]
        private T _value;

        public event Action<T> ValueChanged;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueChanged?.Invoke(value);
            }
        }

#if UNITY_EDITOR
        private void OnValueChangedInEditor(T _)
        {
            ValueChanged?.Invoke(_value);
        }
#endif
    }
}