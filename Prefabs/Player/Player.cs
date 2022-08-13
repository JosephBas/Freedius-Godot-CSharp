using Godot;
using System;
using Freedius;

public class Player : KinematicBody2D
{
    ///// Nodes
    public AnimationPlayer NodeAnimationPlayer  { get; set; }
    public AnimationTree NodeAnimationTree      { get; set; }

    ///// States
    public ActorState PlayerMovement           { get; set; }

    ///// Functions

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Get Nodes
        NodeAnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        NodeAnimationTree = GetNode<AnimationTree>("AnimationTree");
        // Setup Player States
        PlayerMovement = new PlayerEnterStageState(this);
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

