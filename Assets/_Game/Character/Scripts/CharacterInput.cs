namespace Character.Inputs
{
    public abstract class CharacterInput
    {
        public bool Active { get; private set; } = false;
        public float MoveX { get; protected set; }
        public float MoveZ { get; protected set; }
        public void SetActive(bool value)
        {
            Active = value;
        }
    }
}