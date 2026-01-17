namespace Character.ContainerData
{
    //for UI set interface
    public interface ICharacterContainerData
    {
        public event System.Action EventChangeWeaponSate;
        public IMovementState MovementState { get; }
        public IHealthState HealthState { get; }
        public Weapon.ContainerData.IWeaponContainerData WeaponContainerData { get; }
    }
    public class CharacterContainerData : ICharacterContainerData
    {
        public event System.Action EventChangeWeaponSate;
        public readonly MovementState movementState;
        public readonly HealthState healthState;
        public Weapon.ContainerData.IWeaponContainerData weaponContainerData;
        public IMovementState MovementState => movementState;
        public IHealthState HealthState => healthState;
        public Weapon.ContainerData.IWeaponContainerData WeaponContainerData => weaponContainerData;
        public CharacterContainerData()
        {
            movementState = new MovementState();
            healthState = new HealthState();
        }
        public void SetWeaponContainerData(Weapon.ContainerData.IWeaponContainerData weaponContainerData)
        {
            this.weaponContainerData = weaponContainerData;
            EventChangeWeaponSate?.Invoke();
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
        public float Health { get; }
        public float MAXHealth { get; }
    }
    public class HealthState : IHealthState
    {
        public event System.Action EventChangeHealth;
        public float Health { get; private set; }
        public float MAXHealth { get; private set; }
        public HealthState(int maxHealth = 100) {
            MAXHealth = maxHealth;
            SetHealth(MAXHealth);
        }
        public void SetFullHealth()
        {
            SetHealth(MAXHealth);
        }
        public void SetHealth(float health)
        {
            if (Health == health) return;
            if(health < 0) health = 0;
            if (health > MAXHealth) health = MAXHealth;
            Health = health;
            EventChangeHealth?.Invoke();
        }
        public void TakeDamage(float damage)
        {
            if (Health == 0) return;
            Health -= damage;
            if(Health < 0) Health = 0;
            EventChangeHealth?.Invoke();
        }
    } 
}