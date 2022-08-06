namespace Freedius
{
    // General Actor State
    public interface ActorState
    {
        void Start();
        void Update(float delta);
        void FixedUpdate(float delta);
    }
}