using Godot;
using System;

public class MainView : Viewport
{
    void _OnMainViewSizeChanged()
    {
        GD.Print($"Main Viewport size changed! {Size}. Reverting to Base Resolution {Freedius.Globals.BaseResolution}.");
        Size =  Freedius.Globals.BaseResolution;
    }
}
