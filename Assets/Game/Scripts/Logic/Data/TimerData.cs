using Data.Event;
using Data.Variable;

namespace Logic.Data
{
    [System.Serializable]
    public class TimerData
    {
        public AtomicVariable<bool> CanCount;
        
        public AtomicVariable<float> MaxTime;
        public AtomicVariable<float> TimerCounter;
        public AtomicVariable<bool> Finished;
        
        public AtomicEvent FinishEvent;
    }
}