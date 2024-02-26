using UnityEngine;

namespace Tasks.Turn
{
    public sealed class StartTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Turn started!");
            Finish();
        }
    }
}