using UnityEngine;
namespace CameraView
{
    //TODO
    public class ViewData
    {
        public Transform parent;
        public float maxDist;
        public float minDist;
        public bool localView;
        public bool lockX;
        public ViewData(Transform _parent, float _maxDist, float _minDist, bool _localView, bool _lockX)
        {
            parent = _parent;
            maxDist = _maxDist;
            minDist = _minDist;
            localView = _localView;
            lockX = _lockX;
        }
    }
    public class CameraView : MonoBehaviour
    {
        public float x;
        public float y;
        private Inputs.CameraViewInput _input;
        private float _maxDist;
        private float _minDist;
        private float _mouseX = 0;
        private float _mouseY = 0;
        public float mouseSensitivity = 2;
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _distance;
        private ViewData[] _viewData = { new(null, 0, 0, true, true), new(null, 0, 0, false, false) };//first, third;
        private int _currentView = -1;
        public ViewData GetFirstViewData => _viewData[0];
        public ViewData GetThirdViewData => _viewData[1];
        private void Start()
        {
            SetLockCursor(true);
        }
        public void SetInput(Inputs.CameraViewInput input)
        {
            InputOff();
            _input = input;
            InputOn();
        }
        private void OnDestroy()
        {
            SetInput(null);
            SetLockCursor(false);
        }
        private void InputOn()
        {
            if (_input != null)
            {
                _input.EventChangeView += ChangeCamera;
                _input.SetActive(true);
            }
        }
        private void InputOff()
        {
            if (_input != null)
            {
                _input.EventChangeView -= ChangeCamera;
                _input.SetActive(false);
            }
        }
        public void UpdateView(bool setView)
        {
            if (!setView) return;
            _currentView = -1;
            ChangeCamera();
        }
        public void SetLockCursor(bool value)
        {
            if (value)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        public float GetRotationY()
        {
            return _mouseY;
        }
        public void ResetView()
        {
            _mouseX = 0;
            _mouseY = 0;
            SetInput(0, 0, 0);
        }
        public void ChangeCamera()
        {
            _currentView++;
            _currentView %= _viewData.Length;
            _minDist = _viewData[_currentView].minDist;
            _maxDist = _viewData[_currentView].maxDist;
            _input?.SetLockX(_viewData[_currentView].lockX);
            transform.parent = _viewData[_currentView].parent;
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            _distance.transform.SetLocalPositionAndRotation(new Vector3(0, 0, _minDist), Quaternion.identity);
            _camera.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            ResetView();
        }
        public void SetInput(float x = 0, float y = 0, float z = 0)
        {
            if (_viewData[_currentView].localView)
            {
                transform.localRotation = Quaternion.Euler(x, y, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(x, y, 0);
            }
            _camera.transform.localRotation = Quaternion.Euler(0, 0, z);
        }
        private void Rotate()
        {
            float mouseX = _input.MouseXMove * mouseSensitivity;
            float mouseY = _input.MouseYMove * mouseSensitivity;
            _mouseX -= mouseY;
            _mouseY += mouseX;
            _mouseX = Mathf.Clamp(_mouseX, -90, 90);
            _mouseY %= 360;
            SetInput(_mouseX, _mouseY, 0);
            x = _input.MouseXMove;
            y = _input.MouseYMove;
        }
        private void Update()
        {
            if (_input != null)
            {
                Rotate();
                _input.SetYRotation(_mouseY);
                _input.SetXRotation(_mouseX);
            }
        }
    }
}
