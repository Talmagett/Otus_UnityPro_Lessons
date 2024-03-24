using UnityEngine;

namespace Game.Tasks.Turn
{
    public sealed class FinishTurnTask : Task
    {
        protected override void OnRun()
        {
            Finish();
        }
    }
}