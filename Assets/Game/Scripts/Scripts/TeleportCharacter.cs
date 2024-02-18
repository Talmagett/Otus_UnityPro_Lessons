using Lessons.Lesson14_ModuleMechanics;
using Lessons.Lesson15_VisualMechanics;
using Lessons.Lesson16_AtomicComponents;
using UnityEngine;

public class TeleportCharacter : MonoBehaviour
{
    public AtomicEvent<Vector3> Teleported;
    public AtomicVariable<float> Speed;

    private TeleportMechanics _teleportMechanics;
    
    private void Awake()
    {
        _teleportMechanics = new TeleportMechanics(Speed, Teleported, transform);
    }

    private void OnEnable()
    {
        _teleportMechanics.OnEnable();
    }

    private void OnDisable()
    {
        _teleportMechanics.OnDisable();
    }
}