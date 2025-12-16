using UnityEngine.AI;
using VContainer;

public class FollowState : IState
{
    private readonly Character _character;
    private readonly NavMeshAgent _agent;

    public FollowState([Key("player")] Character player, NavMeshAgent agent)
    {
        _character = player;
        _agent = agent;
    }

    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void FixedUpdate()
    {
        _agent.destination = _character.transform.position;
    }

    public void Update()
    {
        
    }
}