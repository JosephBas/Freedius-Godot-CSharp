using Godot;

namespace Freedius
{
    public static class GameGlobals
    {
        // Debug Check Flag
        public static bool IsDebugEnabled { get; set; } = true;
        // Playable Area
        public static Rect2 PlayableArea { get; set; } = new Rect2(16,16,320-16,240-16);
    }
}