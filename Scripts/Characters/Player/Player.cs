using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer animPlayerNode;
    [Export] public Sprite3D spriteNode;
    [Export] public StateMachine stateMachineNode;

    public Vector2 direction = new();

    public override void _Ready()
    {

    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(GameConstants.MOVE_LEFT, GameConstants.MOVE_RIGHT, GameConstants.MOVE_FORWARD, GameConstants.MOVE_BACKWARD);
    }

    public void Flip()
    {

        bool isNotMovingHorizontally = direction.X == 0;

        if (isNotMovingHorizontally)
        {
            return;
        }

        bool isMovingLeft = direction.X < 0;
        spriteNode.FlipH = isMovingLeft;
    }
}

