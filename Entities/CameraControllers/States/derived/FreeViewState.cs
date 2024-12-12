using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    internal class FreeViewState : CameraState, IFreeViewHandler
    {
        protected readonly IFreeCamera _freeCamera;

        internal FreeViewState(IFreeCamera freeCamera) {
            _freeCamera = freeCamera;
        }

        internal override void Update() {
            
        }

        public async void ViewLocation() {
            //await _freeCamera.ShowMap();
            
            // 1) assembly reference
            // 2) generate viewSettings on runtime
            // 3) maybe use parent assembly to automatic reference to childs
        }
    }

    public class ViewLocationSettings
    {
        public List<Vector3> ViewPoints = new List<Vector3>();
    }
}