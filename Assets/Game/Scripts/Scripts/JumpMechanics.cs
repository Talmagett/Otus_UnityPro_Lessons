using Lessons.Lesson14_ModuleMechanics;
using UnityEngine;

public class JumpMechanics
{
    private readonly AtomicVariable<float> _force;
    private readonly AtomicEvent<Vector3> _jumped;
    private readonly Rigidbody _rigidbody;

    public JumpMechanics(AtomicVariable<float> force, AtomicEvent<Vector3> jumped, Rigidbody rigidbody)
    {
        _force = force;
        _jumped = jumped;
        _rigidbody = rigidbody;
    }

    public void OnEnable()
    {
        _jumped.Subscribe(OnJumped);
    }

    public void OnDisable()
    {
        _jumped.Unsubscribe(OnJumped);
    }

    private void OnJumped(Vector3 direction)
    {
        direction.y = 0.5f;
        _rigidbody.AddForce(direction * _force.Value * Time.fixedDeltaTime, ForceMode.Impulse);   
    }
}