using UnityEngine;
using Visual;

namespace Tasks.Turn
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
            Debug.Log("Visual started!");

            _visualPipeline.Finished += OnVisualPipelineFinished;
            _visualPipeline.Run();
        }

        private void OnVisualPipelineFinished()
        {
            Debug.Log("Visual finished!");
            
            _visualPipeline.Finished -= OnVisualPipelineFinished;
            _visualPipeline.Clear();
            
            Finish();
        }
    }
}