using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Turn
{
    public sealed class TurnRunner : MonoBehaviour
    {
        [SerializeField] private bool runOnStart = true;

        [SerializeField] private bool runOnFinish = true;

        private TurnPipeline _turnPipeline;

        private void Start()
        {
            if (runOnStart) Run();
        }

        private void OnEnable()
        {
            _turnPipeline.Finished += OnTurnPipelineFinished;
        }

        private void OnDisable()
        {
            _turnPipeline.Finished -= OnTurnPipelineFinished;
        }

        [Inject]
        private void Construct(TurnPipeline turnPipeline)
        {
            _turnPipeline = turnPipeline;
        }

        [Button]
        public void Run()
        {
            _turnPipeline.Run();
        }

        private void OnTurnPipelineFinished()
        {
            if (runOnFinish) Run();
        }
    }
}