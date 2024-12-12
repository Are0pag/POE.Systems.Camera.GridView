using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal class FocusFollower : IFocusable
    {
        protected readonly UnityEngine.Camera _camera;

        public Transform Target { set; get; }

        internal FocusFollower(UnityEngine.Camera camera) {
            _camera = camera;
        }

        public void Follow() {
            if (!Target) 
                return;
            _camera.transform.position = Target.transform.position;
        }
    }
}