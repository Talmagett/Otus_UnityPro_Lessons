namespace GameManager
{
    public class Listeners
    {
        public interface IGameStateListener
        {
        }

        public interface IOnGameStarted : IGameStateListener
        {
            void OnGameStarted();
        }

        public interface IOnGamePaused : IGameStateListener
        {
            void OnGamePaused();
        }

        public interface IOnGameResumed : IGameStateListener
        {
            void OnGameResumed();
        }

        public interface IOnGameFinished : IGameStateListener
        {
            void OnGameFinished();
        }
    }
}