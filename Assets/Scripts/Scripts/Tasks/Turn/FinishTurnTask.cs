using UnityEngine;

namespace Lessons.Tasks.Turn
{
    public sealed class FinishTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Turn finished!");
            Finish();
        }
    }
}