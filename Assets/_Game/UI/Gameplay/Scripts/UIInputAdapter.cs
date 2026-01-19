using UnityEngine;
using UnityEngine.EventSystems;

namespace UIGameplay.Inputs
{
    public sealed class UIInputAdapter : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [Header("Joystick")]
        [SerializeField] private RectTransform _joystickFrame;
        [SerializeField] private RectTransform _joystickHandle;
        [SerializeField] private float _radius = 60f;

        [Header("Fire Button")]
        [SerializeField] private RectTransform _fireButton;
        [Header("Reload Button")]
        [SerializeField] private RectTransform _reloadButton;
        private ReloadButtonRole _reload;
        [SerializeField] private Canvas _canvas;
        private Camera _uiCamera;

        private UIInputs _inputs;

        private JoystickRole _joystick;
        private FireButtonRole _fire;

        public void Init(UIInputs inputs)
        {
            _inputs = inputs;
            _joystick = new JoystickRole(_joystickFrame, _joystickHandle, _radius, _inputs, _uiCamera);
            _fire = new FireButtonRole(_fireButton, _inputs, _uiCamera);
            _reload = new ReloadButtonRole(_reloadButton, _inputs, _uiCamera);
        }
        private void Awake()
        {
            _uiCamera = _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _canvas.worldCamera;
        }
        public void OnPointerDown(PointerEventData e)
        {
            if (_joystick.IsTarget(e))
                _joystick.OnPointerDown(e);
            else if (_fire.IsTarget(e))
                _fire.OnPointerDown(e);
            else if (_reload.IsTarget(e))
                _reload.OnPointerDown(e);
        }
        public void OnDrag(PointerEventData e)
        {
            _joystick.OnDrag(e);
        }
        public void OnPointerUp(PointerEventData e)
        {
            _joystick.OnPointerUp(e);
            _fire.OnPointerUp(e);
        }
    }
}
