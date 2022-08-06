using Godot;

namespace Freedius
{
    public static class GameDisplay
    {
        // Scaling Factor
        private static float scaling_factor = 1;
        public static float ScalingFactor
        {
            get { return scaling_factor; }
            set
            {
                int max_factor = (int)OS.GetScreenSize().y / (int)BaseResolution.y;
                scaling_factor = Mathf.Clamp(value, 1, max_factor);
            }
        }
        // Base Resultion for viewport and scaling.
        public static Vector2 BaseResolution    { get; } = new Vector2(320, 240);
        // Changes Window and Main Viewport Container Size
        public static void ChangeResolution(ViewportContainer view_container, float scale_factor, bool fullscreen)
        {
            // Change Scaling Factor
            ScalingFactor = scale_factor;
            // Setup new resolution
            Vector2 new_resolution = BaseResolution * ScalingFactor;
            // Set Viewport size
            view_container.RectSize = new_resolution;
            // Set Fullscreen
            OS.WindowFullscreen = fullscreen;

            if ( OS.WindowFullscreen ) // Fullscreen: true
            {
                // Get Half Screen Size
                Vector2 half_screen = OS.GetScreenSize() * 0.5f;
                // Get Half container size
                Vector2 half_view_container = view_container.RectSize * 0.5f;
                // Center View container
                view_container.RectPosition = half_screen - half_view_container;
            }
            else // Fullscreen: false
            {
                // Reset View container position
                view_container.RectPosition = Vector2.Zero;
                // Change Window Size
                OS.WindowSize = new_resolution;
                OS.CenterWindow();
            }
        }
    }
}