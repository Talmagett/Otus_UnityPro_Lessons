using UnityEngine;

namespace Lessons.III.MetaGame.Lesson_RealtimeReward
{
    [CreateAssetMenu(menuName = "Lesson/Realtime/MoneyRewardConfig", fileName = "TimeRewardConfig", order = 0)]
    public class TimeRewardConfig : ScriptableObject
    {
        public float Duration = 5f;
        public int MoneyReward = 100;
    }
}