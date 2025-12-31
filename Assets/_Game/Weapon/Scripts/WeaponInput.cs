namespace Weapon.Inputs
{
    public abstract class WeaponInput
    {
        public event System.Action EventAttackPressed;
        public event System.Action EventAttackReleased;
        public event System.Action Reload;
        //TODO
    }
}