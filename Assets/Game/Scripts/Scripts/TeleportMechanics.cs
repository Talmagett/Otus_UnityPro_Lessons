using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

public class TeleportMechanics
{
    private readonly AtomicVariable<float> _speed;
    private readonly AtomicEvent<Vector3> _teleported;
    private readonly Transform _transform;

    public TeleportMechanics(AtomicVariable<float> speed, AtomicEvent<Vector3> teleported, Transform transform)
    {
        _transform = transform;
        _speed = speed;
        _teleported = teleported;
    }

    public void OnEnable()
    {
        _teleported.Subscribe(OnTeleported);
    }

    public void OnDisable()
    {
        _teleported.Unsubscribe(OnTeleported);
    }

    private void OnTeleported(Vector3 direction)
    {
        _transform.position = direction * _speed.Value * Time.deltaTime;
    }
}