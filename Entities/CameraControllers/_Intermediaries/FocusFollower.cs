using UnityEngine;

namespace Scripts.Systems.Camera.LocationView
{
    internal class FocusFollower : IFocusable
    {
        protected readonly UnityEngine.Camera _camera;

        internal FocusFollower(UnityEngine.Camera camera) {
            _camera = camera;
        }

        public void Follow(Transform target) {
            _camera.transform.position = new Vector3(target.position.x, target.position.y, Config.CAMERA_POS_Z);
        }
    }
}