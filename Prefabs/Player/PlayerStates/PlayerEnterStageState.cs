using Godot;

namespace Freedius
{
    // Default Enter Stage: Player Enter Stage with Collision Masks disabled
    public class PlayerEnterStageState : ActorState
    {
        ///// Variables
        // Player Reference
        Player player_ref;

        ///// Constructor
        public PlayerEnterStageState(Player p)
        {
            player_ref = p;
            Start();
        }

        ///// Startup
        public void Start()
        {
            // Set Initial position outside screen
            player_ref.Position = new Vector2(-64, 120);
            // Set Collision Mask and Layer to 0
            //player_ref.CollisionLayer = 0;
            //player_ref.CollisionMask = 0;
        }

        public void Update(float delta)
        {
            // Flicker
            player_ref.Visible = !player_ref.Visible;
            // Move towards a certain point
            player_ref.Translate(Vector2.Right * 3);
            // Give control to player
            if ( player_ref.Position.x >= 64)
            {
                player_ref.PlayerMovement = new PlayerDefaultMovementState(player_ref);
            }
        }

        public void FixedUpdate(float delta) {}
    }

}