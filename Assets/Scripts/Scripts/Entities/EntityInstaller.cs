using Entities;
using Lessons.Entities.Common.Components;
using Lessons.Level;
using UnityEngine;
using Zenject;


namespace Lessons.Entities
{
    public sealed class EntityInstaller : MonoBehaviour
    {
        [SerializeField]
        private MonoEntity[] entities;

        private LevelMap _levelMap;

        [Inject]
        private void Construct(LevelMap levelMap)
        {
            _levelMap = levelMap;
        }
        
        private void Start()
        {
            foreach (var entity in entities)
            {
                var coordinates = entity.Get<CoordinatesComponent>();
                var position = entity.Get<PositionComponent>();
                coordinates.Value = _levelMap.Tiles.PositionToCoordinates(position.Value);
                position.Value = _levelMap.Tiles.CoordinatesToPosition(coordinates.Value);
                
                _levelMap.Entities.SetEntity(coordinates.Value, entity);
            }
        }
    }
}