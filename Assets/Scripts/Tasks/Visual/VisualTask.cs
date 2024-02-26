namespace Tasks.Visual
{
    public abstract class VisualTask : Task
    {
        public static VisualTask Combine(VisualTask first, VisualTask second)
        {
            if (first is null)
            {
                return second;
            }

            if (second is null)
            {
                return first;
            }

            if (first is CompositeVisualTask firstCompositeTask)
            {
                firstCompositeTask.Add(second);
                return first;
            }
            
            if (second is CompositeVisualTask secondCompositeTask)
            {
                secondCompositeTask.Add(first);
                return second;
            }

            return new CompositeVisualTask(first, second);
        }
        
        public abstract bool Sticky { get; protected set; }
    }
}