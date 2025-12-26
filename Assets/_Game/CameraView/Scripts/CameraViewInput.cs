using UnityEngine;
namespace CameraView.Inputs
{
    public abstract class CameraViewInput
    {
        //TODO
        private bool _active = false;
        private float _cameraRotationX;
        private float _cameraRotationY;
        public event System.Action EventChangeView;
        protected Transform _parent;

        protected float _mouseXMove;
        protected float _mouseYMove;
        protected bool _lockX;
        public float MouseXMove => _lockX ? 0 : _mouseXMove;
        public float MouseYMove => _mouseYMove;
        public float LockMouseXMove => _lockX ? _mouseXMove : 0;
        public float CameraRotationX => _cameraRotationX;
        public float CameraRotationY => _cameraRotationY;
        public bool LockX => _lockX;
        public Transform Parent => _parent;
        public bool Active => _active;
        public void SetLockX(bool value) { _lockX = value; }
        public void SetActive(bool value) { _active = value; }
        public void SetYRotation(float rotation)
        {
            _cameraRotationY = rotation;
        }
        public void SetXRotation(float rotation)
        {
            _cameraRotationX = rotation;
        }
        protected void ChangeView()
        {
            EventChangeView?.Invoke();
        }
    }
}