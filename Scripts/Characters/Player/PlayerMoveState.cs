using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{

    [Export(PropertyHint.Range, "0,20,0.1")] private float moveSpeed = 6.0f;

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
        }

        characterNode.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);
        characterNode.Velocity *= moveSpeed;
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }


    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.DASH))
        {
            characterNode.StateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimPlayerNode.Play(GameConstants.ANIMATION_MOVE);
    }
}
