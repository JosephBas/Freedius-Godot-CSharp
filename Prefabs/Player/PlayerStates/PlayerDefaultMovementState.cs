using Godot;

namespace Freedius
{
    // Default Player Movement: Move around and change speeds
    public class PlayerDefaultMovementState : ActorState
    {
        ///// Variables

        // Player Reference
        Player player_ref;

        // Animation
        AnimationNodeStateMachinePlayback animation_state_machine;

        // Movement
        Vector2 direction;
        float speed;

        // Constructor
        public PlayerDefaultMovementState(Player p)
        {
            player_ref = p;
        }

        // Startup
        public void Start()
        {
            // Get Animation State Machine reference
            animation_state_machine = (AnimationNodeStateMachinePlayback)player_ref.NodeAnimationTree.Get("parameters/playback");
            // Initialize direction vector
            direction = new Vector2(0, 0);
            // Initialize speed
            speed = 2.0f;
        }

        // Update
        public void Update(float delta)
        {
            // Read Movement Input
            direction.x = Input.GetActionStrength("game_right") - Input.GetActionStrength("game_left");
            direction.y = Input.GetActionStrength("game_down")  - Input.GetActionStrength("game_up");

            // Change Animation
            if ( direction.y > 0 )
            {
                animation_state_machine.Travel("down");
            }
            else if ( direction.y < 0 )
            {
                animation_state_machine.Travel("up");
            }
            else if ( direction.y == 0 && !player_ref.NodeAnimationPlayer.IsPlaying() )
            {
                animation_state_machine.Travel("idle");
            }

            // Speed Change Input
            if ( Input.IsActionJustPressed("game_speed_up") )
            {
                speed = Mathf.Clamp(speed + 2, 2, 6);
            }
            else if ( Input.IsActionJustPressed("game_speed_down") )
            {
                speed = Mathf.Clamp(speed - 2, 2, 6);
            }
        }

        // Fixed Update (Physics)
        public void FixedUpdate(float delta)
        {
            // Move
            player_ref.MoveAndCollide(direction * speed);
            
            // Clamp player position to a limit Area
            if (player_ref.Position.x < GameGlobals.PlayableArea.Position.x ||
                player_ref.Position.x > GameGlobals.PlayableArea.Size.x     ||
                player_ref.Position.y < GameGlobals.PlayableArea.Position.y ||
                player_ref.Position.y > GameGlobals.PlayableArea.Size.y)
            {
                Vector2 clamped_position = new Vector2();
                clamped_position.x = Mathf.Clamp(player_ref.Position.x, GameGlobals.PlayableArea.Position.x, GameGlobals.PlayableArea.Size.x);
                clamped_position.y = Mathf.Clamp(player_ref.Position.y, GameGlobals.PlayableArea.Position.y, GameGlobals.PlayableArea.Size.y);
                player_ref.Position = clamped_position;
            }
        }
    }
}