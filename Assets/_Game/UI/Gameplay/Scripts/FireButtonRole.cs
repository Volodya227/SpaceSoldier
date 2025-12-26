using UnityEngine;
using UnityEngine.EventSystems;

namespace UIGameplay.Inputs
{
    internal sealed class FireButtonRole
    {
        private readonly RectTransform _button;
        private readonly UIInputs _inputs;
        private readonly Camera _uiCamera;
        public FireButtonRole(RectTransform button, UIInputs inputs, Camera uiCamera)
        {
            _button = button;
            _inputs = inputs;
            _uiCamera = uiCamera;
        }
        public bool IsTarget(PointerEventData e)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(_button, e.position, _uiCamera);
        }
        public void OnPointerDown(PointerEventData e)
        {
            _inputs.SignalFire();
        }
    }
}
