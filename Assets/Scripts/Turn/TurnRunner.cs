using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Turn
{
    public sealed class TurnRunner : MonoBehaviour
    {
        [SerializeField]
        private bool runOnStart = true;

        [SerializeField]
        private bool runOnFinish = true;
        
        private TurnPipeline _turnPipeline;

        [Inject]
        private void Construct(TurnPipeline turnPipeline)
        {
            _turnPipeline = turnPipeline;
        }
        
        private void OnEnable()
        {
            _turnPipeline.Finished += OnTurnPipelineFinished;
        }

        private void OnDisable()
        {
            _turnPipeline.Finished -= OnTurnPipelineFinished;
        }

        private void Start()
        {
            if (runOnStart)
            {
                Run();
            }
        }

        [Button]
        public void Run()
        {
            _turnPipeline.Run();
        }

        private void OnTurnPipelineFinished()
        {
            if (runOnFinish)
            {
                Run();
            }
        }
    }
}