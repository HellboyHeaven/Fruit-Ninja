using UnityEngine;

public sealed class TransformMovement : IMovement
{
    private readonly Transform _transform;
    
    public TransformMovement(Transform transform)
    {
        _transform = transform;
    }

    public void Move(Vector3 input)
    {
        _transform.position += input;
    }
}
