
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Scripts.Systems.Camera.GridView
{
    /*
     * состояния камеры должны быть публичными классами, и присваивать их необходимо из интерфейса модуля
     */
    public class ViewModule
    {
        private readonly GridViewer _gridViewer;
        
        public SwapState SwapState { get; }
        public FocusState FocusState { get; }
        
        internal ViewModule(GridViewer viewer, SwapState swapState, FocusState focusState) {
            _gridViewer = viewer;
            SwapState = swapState;
            FocusState = focusState;
        }
        
        public void SetState(CameraState state) => _gridViewer.SwitchState(state);

        /*public async UniTask RunLocationView(List<Vector3> waypoints) {
            await FreeViewState.ViewLocation(new ShowMapArgs(waypoints));
        }*/
    }
}