using Godot;
using System;
using Freedius;

public class GameManager : Node
{
    ///// Nodes
    public ViewportContainer ViewContainer { get; set; }

    ///// Functions


    // Class Functions

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ViewContainer = GetNode<ViewportContainer>("ViewContainer");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if ( GameGlobals.IsDebugEnabled )
        {
            if ( Input.IsActionJustPressed("DEBUG_RESOLUTION_UP") )
            {
                GameDisplay.ChangeResolution(ViewContainer, GameDisplay.ScalingFactor + 1, OS.WindowFullscreen);
            }
            else if ( Input.IsActionJustPressed("DEBUG_RESOLUTION_DOWN") )
            {
                GameDisplay.ChangeResolution(ViewContainer, GameDisplay.ScalingFactor - 1, OS.WindowFullscreen);
            }
            else if ( Input.IsActionJustPressed("DEBUG_FULLSCREEN") )
            {
                GameDisplay.ChangeResolution(ViewContainer, GameDisplay.ScalingFactor, !OS.WindowFullscreen);
            }
        }
        
    }
}
