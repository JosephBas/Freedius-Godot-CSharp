using Godot;

namespace Freedius
{
    public static class Globals
    {
        public static bool IsDebugEnabled { get; set; } = true;
        public static Vector2 BaseResolution { get; }   = new Vector2(320, 240);
        public static float ScalingFactor { get; set; } = 1.0f;
        public static float MaxScalingFactor { get; } = OS.GetScreenSize().y / 0.5f;
    }
}