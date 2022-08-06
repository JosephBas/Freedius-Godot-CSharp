using Godot;

namespace Freedius
{
    public class PlayerDefaultMovementState : ActorState
    {

        // Player Reference
        Player player;

        // Movement
        Vector2 direction;
        float speed;

        // Constructor
        public PlayerDefaultMovementState(Player p)
        {
            player = p;
        }

        // Startup
        public void Start()
        {
            speed = 2.0f;
        }

        // Update
        public void Update(float delta)
        {
            // Read Movement Input
            direction.x = Input.GetActionStrength("game_right") - Input.GetActionStrength("game_left");
            direction.y = Input.GetActionStrength("game_down") - Input.GetActionStrength("game_up");

            // Speed Chnge Input
            //speed += (Input.IsActionJustPressed("game_right") - Input.IsActionJustPressed("game_left"));
        }

        // Fixed Update (Physics)
        public void FixedUpdate(float delta)
        {
            // Move
            player.MoveAndCollide(direction * speed);
        }
    }
}