namespace Character.ContainerData
{
    //for UI set interface
    public interface ICharacterContainerData
    {
        public IMovementState MovementState { get; }
        public IHealthState HealthState { get; }
    }
    public class CharacterContainerData : ICharacterContainerData
    {
        public readonly MovementState movementState;
        public readonly HealthState healthState;
        public IMovementState MovementState => movementState;
        public IHealthState HealthState => healthState;
        public CharacterContainerData()
        {
            movementState = new MovementState();
            healthState = new HealthState();
        }
    }
    public interface IMovementState
    {
        public event System.Action EventChangeDirectionMoving;
        public float MoveX { get; }
        public float MoveZ { get; }
    }
    public class MovementState : IMovementState
    {
        public event System.Action EventChangeDirectionMoving;
        public float MoveX { get; private set; }
        public float MoveZ { get; private set; }
        public void SetDirectionMoving(float x, float z)
        {
            if (MoveX == x && MoveZ == z) return;
            MoveX = x;
            MoveZ = z;
            EventChangeDirectionMoving?.Invoke();
        }
    }
    public interface IHealthState
    {
        public event System.Action EventChangeHealth;
        public int Health { get; }
    }
    public class HealthState : IHealthState
    {
        public event System.Action EventChangeHealth;
        public int Health { get; private set; }
        public void SetHealth(int health)
        {
            if (Health == health) return;
            Health = health;
            EventChangeHealth?.Invoke();
        }
    } 
}