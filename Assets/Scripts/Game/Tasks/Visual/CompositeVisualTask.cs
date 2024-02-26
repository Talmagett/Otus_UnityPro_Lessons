using System.Collections.Generic;

namespace Game.Tasks.Visual
{
    public sealed class CompositeVisualTask : VisualTask
    {
        private readonly List<VisualTask> _tasks = new();

        private int _counter;

        public CompositeVisualTask(params VisualTask[] tasks)
        {
            foreach (var task in tasks) Add(task);
        }

        public override bool Sticky { get; protected set; } = true;

        public void Add(VisualTask task)
        {
            if (!task.Sticky) Sticky = false;

            _tasks.Add(task);
        }

        protected override void OnRun()
        {
            _counter = 0;

            foreach (var task in _tasks) task.Run(OnTaskFinished);
        }

        private void OnTaskFinished(Task _)
        {
            ++_counter;

            if (_counter >= _tasks.Count) Finish();
        }
    }
}