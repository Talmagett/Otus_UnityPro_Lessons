using Data.Variable;

namespace Logic.Data
{
    [System.Serializable]
    public class ResourceData
    {
        public AtomicVariable<int> Count;
        public AtomicVariable<int> MaxCount;

        public bool IsEmpty => Count.Value == 0;
        public bool IsFull => Count.Value >= MaxCount.Value;
    }
}