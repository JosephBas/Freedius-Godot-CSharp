using Godot;
using System;
using Freedius;

public class View : Viewport
{
    public void _OnViewSizeChanged()
    {
        GD.Print($"View Size changed: {Size}");
        Size = GameDisplay.BaseResolution;
        GD.Print($"View Size reverted: {Size}");
    }
}
