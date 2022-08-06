using Godot;
using System;
using Freedius;

public class Player : KinematicBody2D
{
    ///// Properties
    ActorState PlayerMovement { get; set; }

    ///// Functions

    // Class Functions

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Setup Player States
        PlayerMovement = new PlayerDefaultMovementState(this);
        PlayerMovement.Start();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // Manage Player Input and Movement
        PlayerMovement.Update(delta);
    }

    public override void _PhysicsProcess(float delta)
    {
        // Manage Player Movement (Physics)
        PlayerMovement.FixedUpdate(delta);
    }
}

