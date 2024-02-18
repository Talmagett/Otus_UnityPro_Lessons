using Lessons.Lesson14_ModuleMechanics;
using Lessons.Lesson15_VisualMechanics;
using UnityEngine;

public class JumpCharacter : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public AtomicEvent<Vector3> Jumped;
    public AtomicVariable<float> Force;

    private JumpMechanics _jumpMechanics;
    
    private void Awake()
    {
        _jumpMechanics = new JumpMechanics(Force, Jumped, Rigidbody);
    }

    private void OnEnable()
    {
        _jumpMechanics.OnEnable();
    }

    private void OnDisable()
    {
        _jumpMechanics.OnDisable();
    }
}