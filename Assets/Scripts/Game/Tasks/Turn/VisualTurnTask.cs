using Game.Visual;
using UnityEngine;

namespace Game.Tasks.Turn
{
    public sealed class VisualTurnTask : Task
    {
        private readonly VisualPipeline _visualPipeline;

        public VisualTurnTask(VisualPipeline visualPipeline)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnRun()
        {
            _visualPipeline.Finished += OnVisualPipelineFinished;
            _visualPipeline.Run();
        }

        private void OnVisualPipelineFinished()
        {
            _visualPipeline.Finished -= OnVisualPipelineFinished;
            _visualPipeline.Clear();

            Finish();
        }
    }
}