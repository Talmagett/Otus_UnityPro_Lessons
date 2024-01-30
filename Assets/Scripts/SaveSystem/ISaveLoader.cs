using GameEngine;

namespace SaveSystem
{
    public interface ISaveLoader
    {
        void LoadGame(IGameRepository repository, GameContext context);

        void SaveGame(IGameRepository repository, GameContext context);
    }
}