using UnityEngine;

[RequireComponent(typeof(StatsContext))]
public class Character : MonoBehaviour
{
    public IMovement Movement {get; private set;}
    public StatsContext Stats {get; private set;}

    protected void Awake()
    {
        Movement = new TransformMovement(transform);
        Stats = GetComponent<StatsContext>();
    }
}