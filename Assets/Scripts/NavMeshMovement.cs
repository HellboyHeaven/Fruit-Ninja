using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : IMovement
{
    private readonly NavMeshAgent _agent;

    public NavMeshMovement(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public void Move(Vector3 target)
    {
        _agent.destination = target;
    }
}
