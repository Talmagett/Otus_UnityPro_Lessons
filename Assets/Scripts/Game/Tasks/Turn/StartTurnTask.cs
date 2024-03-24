using UnityEngine;

namespace Game.Tasks.Turn
{
    public sealed class StartTurnTask : Task
    {
        protected override void OnRun()
        {
            Finish();
        }
    }
}