using GameManager;

namespace Enemy.Agents
{
    public class EnemyMoveAttackController:
        IGameFixedUpdateListener
    {
        private readonly GameManager.GameManager _gameManager;
        private readonly EnemyAttackAgent _enemyAttackAgent;
        private readonly EnemyMoveAgent _enemyMoveAgent;

        public EnemyMoveAttackController(GameManager.GameManager gameManager,EnemyAttackAgent enemyAttackAgent, EnemyMoveAgent enemyMoveAgent)
        {
            _gameManager = gameManager;
            _enemyAttackAgent = enemyAttackAgent;
            _enemyMoveAgent = enemyMoveAgent;
        }
        
        public void Initialize()
        {
            _gameManager.AddListener(this);
            _gameManager.AddListener(_enemyMoveAgent);
        }
        
        public void Dispose()
        {
            _gameManager.RemoveListener(this);
            _gameManager.RemoveListener(_enemyMoveAgent);
        }

        public void OnGameFixedUpdate(float deltaTime)
        {
            if(_enemyMoveAgent.IsReached)
                _enemyAttackAgent.OnGameFixedUpdate(deltaTime);
        }
    }
}