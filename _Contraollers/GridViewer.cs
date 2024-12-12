using System.Diagnostics.CodeAnalysis;
using Zenject;

namespace Scripts.Systems.Camera.GridView
{
    internal class GridViewer : ITickable
    {
        internal protected CameraState CurrentState { get; protected set; }
        internal protected FocusState FocusState { get; protected set; }

        internal GridViewer(FocusState focusState) {
            FocusState = focusState;
        }

        internal void SwitchState([DisallowNull] CameraState newState) {
            CurrentState = newState;
        }

        void ITickable.Tick() => CurrentState?.Update();
    }
}