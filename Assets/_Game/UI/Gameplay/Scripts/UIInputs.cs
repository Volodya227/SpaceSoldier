namespace UIGameplay.Inputs
{
    public interface IUIInputs
    {
        public event System.Action EventAttackPressed;
        public event System.Action EventAttackReleased;
        public event System.Action EventReloading;
        public float MoveX { get;}
        public float MoveZ { get; }
    }
    [System.Serializable]
    public sealed class UIInputs : IUIInputs
    {
        public event System.Action EventAttackPressed;
        public event System.Action EventAttackReleased;
        public event System.Action EventReloading;
        public float MoveX { get; private set; }
        public float MoveZ { get; private set; }
        public void SignalMove(float x, float z)
        {
            MoveX = x;
            MoveZ = z;
        }
        public void SignalMoveRelease()
        {
            Reset();
        }
        public void SignalAttackPressed()
        {
            EventAttackPressed?.Invoke();
        }
        public void SignalAttackReleased()
        {
            EventAttackReleased?.Invoke();
        }
        public void SignalReloading()
        {
            EventReloading?.Invoke();
        }
        public void Reset()
        {
            MoveX = 0;
            MoveZ = 0;
        }
    }
    public class UIInputsNullReference : IUIInputs
    {
        public event System.Action EventAttackPressed;
        public event System.Action EventAttackReleased;
        public event System.Action EventReloading;
        public float MoveX => 0;
        public float MoveZ => 0;
    }
}