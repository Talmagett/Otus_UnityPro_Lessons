using System;
using System.Collections.Generic;
using System.Linq;
using Lessons.Tasks;
using Lessons.Tasks.Visual;
using Sirenix.OdinInspector;

namespace Lessons.Visual
{
    public sealed class VisualPipeline
    {
        public event Action Finished;

        [ShowInInspector, ReadOnly]
        private readonly List<VisualTask> _tasks = new();

        private int _currentIndex = -1;

        public void AddTask(VisualTask task)
        {
            var lastLast = _tasks.LastOrDefault();

            if (lastLast is null || !lastLast.Sticky && !task.Sticky)
            {
                _tasks.Add(task);
            }
            else
            {
                _tasks[^1] = VisualTask.Combine(lastLast, task);
            }
        }

        public void Clear()
        {
            _tasks.Clear();
        }
        
        public void Run()
        {
            _currentIndex = 0;
            RunNextTask();
        }

        private void RunNextTask()
        {
            if (_currentIndex >= _tasks.Count)
            {
                Finished?.Invoke();
                return;
            }

            var task = _tasks[_currentIndex];
            task.Run(OnTaskFinished);
        }

        private void OnTaskFinished(Task task)
        {
            ++_currentIndex;
            RunNextTask();
        }
    }
}