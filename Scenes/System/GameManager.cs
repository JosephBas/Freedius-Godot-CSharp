using Godot;
using System;
using Freedius;

public class GameManager : Node
{   
    ///// Nodes
    ViewportContainer view_container;

    ///// Variables

    ///// Functions

    // Changed Window and Viewport Container Size
    public void ChangeResolution(Vector2 new_resolution)
    {
        // In Windowed Mode
        if ( !OS.WindowFullscreen )
        {
            // Change Window Size
            OS.WindowSize = new_resolution;
            OS.CenterWindow();
        }
        else // Fullscreen
        {
            // Chnage Viewport Container Size
            view_container.RectSize = new_resolution;
        }
    }

    ///// Class Functions

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Get Nodes
        view_container  = GetNode<ViewportContainer>("MainViewContainer");

        // Set Default Resolution
        Globals.ScalingFactor = 2.0f;
        ChangeResolution(Globals.BaseResolution * Globals.ScalingFactor);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if ( Globals.IsDebugEnabled )
        {
            if ( Input.IsActionJustPressed("debug_resolution_up") )
            {
                // Get Screen Height / Base Resolution relation
                int height_relation = (int)(OS.GetScreenSize().y / Globals.BaseResolution.y);
                // Increase Scaling Factor
                Globals.ScalingFactor += 0.5f;
                // If Scaling Factor is over relation clamp it
                if ( Globals.ScalingFactor > height_relation )
                    Globals.ScalingFactor = height_relation;
                // Change Resolution
                ChangeResolution(Globals.BaseResolution * Globals.ScalingFactor);
            }
            else if ( Input.IsActionJustPressed("debug_resolution_down") )
            {
                // Decrease Scaling Factor
                Globals.ScalingFactor -= 0.5f;
                // If Scaling Factor is below 1 set it to 1
                if ( Globals.ScalingFactor < 1 )
                    Globals.ScalingFactor = 1;
                // Change Resolution
                ChangeResolution(Globals.BaseResolution * Globals.ScalingFactor);
            }
        }
    }
}
