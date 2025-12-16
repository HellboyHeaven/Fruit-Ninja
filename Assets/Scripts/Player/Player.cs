using UnityEngine;

public class Player : Character
{
    private InputSystem_Actions actions;

    private void Awake()
    {
        base.Awake();
        actions = new InputSystem_Actions();
        actions.Enable();
    }

    private void Update()
    {
        var speed = Stats.Get<Speed>();
        var input = actions.Player.Move.ReadValue<Vector2>();
        Movement.Move(new Vector3(input.x, 0, input.y) * speed.Value  * Time.deltaTime);
    }
}