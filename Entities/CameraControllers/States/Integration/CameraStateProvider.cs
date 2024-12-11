using System.Diagnostics.CodeAnalysis;
using Cysharp.Threading.Tasks;

namespace Scripts.Systems.Camera.GridView
{
    internal class CameraStateProvider
    {
        protected readonly IGidViewer _gidViewer;
        
        internal protected CameraState CurrentState { get; protected set; }
        internal protected FocusState FocusState { get; protected set; }

        internal CameraStateProvider(IGidViewer gidViewer, FocusState focusState) {
            _gidViewer = gidViewer;
            FocusState = focusState;
        }

        internal void UpdateState() => CurrentState?.Update();

        internal async UniTask SwitchState([DisallowNull] CameraState newState) {
            CurrentState?.OnSwitch(); // can be null on start
            CurrentState = null;
            
            await newState.OnEnter();
            
            CurrentState = newState;
        }
    }
}