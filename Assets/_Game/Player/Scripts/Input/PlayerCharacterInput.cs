namespace Player.Inputs
{
    public class PlayerCharacterInput : Character.Inputs.CharacterInput
    {
        public void SetMoving(float x, float z)
        {
            MoveX = x;
            MoveZ = z;
        }
    }
}