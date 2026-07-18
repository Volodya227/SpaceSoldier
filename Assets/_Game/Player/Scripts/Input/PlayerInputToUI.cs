namespace Player.Inputs
{
    public class PlayerInputToUI: UIGameplay.Inputs.InputToUI
    {
        public void EventEnterActivation()
        {
            EventEnterActivate();
        }
        public void EventEscapeActivation()
        {
            EventEscapeActivate();
        }
        public bool EventAskActiveUIActivation()
        {
            return EventAskActiveUIActivate();
        }
    }
}