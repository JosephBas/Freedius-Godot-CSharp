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
        float base_speed;
        float extra_speed;

        // Update Animation/BlendTrees Speed
        void UpdateAnimationSpeed()
        {
            player_ref.NodeAnimationTree.Set("parameters/up/TimeScale/scale",           0.75f + (extra_speed / base_speed));
            player_ref.NodeAnimationTree.Set("parameters/up_reverse/TimeScale/scale",   0.75f + (extra_speed / base_speed));
            player_ref.NodeAnimationTree.Set("parameters/down/TimeScale/scale",         0.75f + (extra_speed / base_speed));
            player_ref.NodeAnimationTree.Set("parameters/down_reverse/TimeScale/scale", 0.75f + (extra_speed / base_speed));
        }

        // Constructor
        public PlayerDefaultMovementState(Player p)
        {
            player_ref = p;
        }

        // Startup
        public void Start()
        {
            // Get Animation State Machine reference
            animation_state_machine = (AnimationNodeStateMachinePlayback) player_ref.NodeAnimationTree.Get("parameters/playback");
            // Initialize direction vector
            direction   = new Vector2(0, 0);
            // Initialize Base Speed
            base_speed  = 2.0f;
            // Initialize Extra Speed
            extra_speed = 0.0f;
            // Setup Animation Speed
            UpdateAnimationSpeed();
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
                // Travel to "down" node
                animation_state_machine.Travel("down");
            }
            else if ( direction.y < 0 )
            {
                // Travel to "up" node
                animation_state_machine.Travel("up");
            }
            else if ( direction.y == 0 && !player_ref.NodeAnimationPlayer.IsPlaying() )
            {
                // Travel to "idle" node
                animation_state_machine.Travel("idle");
            }

            // Speed Change Input
            if ( Input.IsActionJustPressed("game_speed_up") )
            {
                extra_speed = Mathf.Clamp(extra_speed + 1, 0, 3);
                //GD.Print($"Speed Level: {extra_speed + 1}");
                UpdateAnimationSpeed();
            }
            else if ( Input.IsActionJustPressed("game_speed_down") )
            {
                extra_speed = Mathf.Clamp(extra_speed - 1, 0, 3);
                //GD.Print($"Speed Level: {extra_speed + 1}");
                UpdateAnimationSpeed();
            }
        }

        // Fixed Update (Physics)
        public void FixedUpdate(float delta)
        {
            // Move
            player_ref.MoveAndCollide(direction * (base_speed + extra_speed) );
            
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